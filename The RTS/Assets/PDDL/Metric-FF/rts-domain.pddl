(define (domain rts)
  (:requirements :strips :typing)
  
   (:types         
	person - object
	
	location - object
	forest - location	
	miningResource - location
	stone - location
	building - location
	
	
	
	
	)
	
   (:predicates
		
		(at ?p - person ?pl - location)
		(is-person ?person - person)
		(is-labourer ?person - person)
		(is-carpenter ?person - person)
		(is-lumberjack ?person - person)
		(is-miner ?person - person)
		(is-blacksmith ?person - person)
		(is-teacher ?person - person)
		
		(has-wood ?pl - location)
		(has-mineral ?pl - location)
		
		(has-turfhut ?pl - location)
		(has-house ?pl - location)
		(has-school ?pl -location)
		(has-barracks ?pl -location)
		(has-storage ?pl -location)
		(has-mine ?pl - location)
		(has-smelter ?pl -location)
		(has-quary ?pl -location)
		(has-sawmill ?pl - location)
		(has-refinery ?pl - location) ;;blacksmith
		(has-marketStall ?pl - location)
		
		;;----------------------------------;;
		
		(has-skill ?p - person)
		(has-riflemanSkill ?p - person)
		
		(got-wood ?p - person ?pl - location)
		(got-resource ?p - person)
		(got-baby ?p1 - person ?p2 - person)
		
		
		;;----------------------------------;;
		
		(at-balloon ?place - location)
		(in-balloon ?person - person)
		(has-coconuts ?pl - location)
		(got-coconuts ?p - person ?pl - location)

		
;;		(my-new-pred ?a ?b ?c ?d - location ?e - person ?f - location)
   )
   
   ;;----------------Actions-----------------;;
	   
  	(:action simpletrain
			:parameters (?teacher - person ?student - person ?location - location)
			:precondition (and (at ?teacher ?location) (at ?student ?location) (not (has-skill ?student)))
			:effect (has-skill ?student))
			
	(:action schooltrain
			:parameters (?teacher - person ?student - person ?location - building)
			:precondition (and (at ?teacher ?location) (at ?student ?location) (has-school ?location) (not (has-skill ?student)))
			:effect (has-skill ?student))
	
	(:action trainCarpenter
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-carpenter ?person)))
			:effect (is-carpenter ?person))
	
	(:action trainLumberjack
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-lumberjack ?person)))
			:effect (is-lumberjack ?person))
			
	(:action trainMiner
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-miner ?person)))
			:effect (is-miner ?person))
			
	(:action trainBlacksmith
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-blacksmith ?person)))
			:effect (is-blacksmith ?person))
			
	(:action trainTeacher
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-teacher ?person)))
			:effect (is-teacher ?person))
	
	(:action trainRifleman
			:parameters (?person - person ?place - building)
			:precondition(and (has-skill ?person) (has-barracks ?place) (not (has-riflemanSkill ?person)))
			:effect (has-riflemanSkill ?person))
	
	
	
	;;--------------------------------------;;
	
	

	(:action move
			:parameters (?person - person ?pl-from ?pl-to - location)
			:precondition (and (at ?person ?pl-from))
			:effect (and (at ?person ?pl-to) (not (at ?person ?pl-from))))
			
	(:action cuttree
			:parameters (?person - person ?place - forest)
			:precondition (and (is-lumberjack ?person)(at ?person ?place) (has-wood ?place) (not(got-wood ?person ?place)))
			:effect (and (got-wood ?person ?place) (not (has-wood ?place))))

	(:action multiplySingle
			:parameters (?person1 - person ?person2 - person ?place - location)
			:precondition (and (at ?person1 ?place) (at ?person2 ?place) )
			:effect (got-baby ?person1 ?person2))
			
	(:action multiplyDouble
			:parameters (?person1 - person ?person2 - person ?place - location)
			:precondition (and (at ?person1 ?place) (at ?person2 ?place) )
			:effect (got-baby ?person1 ?person2))		
	
	(:action store
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (got-resource ?person))
			:effect (not (got-resource ?person)))
	
	;;do need different types of mineral 
	
	;;----------------Buildings-----------------;;
	
	
	
   	(:action buildTurfHut
			:parameters (?person - person ?location - building)
			:precondition (and (at ?person ?location) (is-labourer ?person) (not (has-turfhut ?location)))
			:effect (has-turfhut ?location))
			
	(:action buildHouse
			:parameters (?person1 - person ?person2 - person ?location - building)
			:precondition (and (at ?person1 ?location)(at ?person2 ?location) (is-carpenter ?person1)  (is-labourer ?person2) (not (has-house ?location)))
			:effect (has-house ?location))
			
	(:action buildSchool
			:parameters (?person1 - person ?person2 - person ?place - building)
			:precondition (and (at ?person1 ?place)(at ?person2 ?place) (is-carpenter ?person1)(is-labourer ?person2)(not(has-school ?place)))
			:effect (has-school ?place))
			
	(:action buildBarracks
			:parameters (?person1 - person ?person2 - person ?place - building)
			:precondition (and (at ?person1 ?place)(at ?person2 ?place) (is-carpenter ?person1)(is-labourer ?person2)(not(has-barracks ?place)))
			:effect (has-barracks ?place))
			
	(:action buildStorage
			:parameters (?person1 - person ?person2 - person ?place - building)
			:precondition (and (at ?person1 ?place)(at ?person2 ?place) (is-carpenter ?person1)(is-labourer ?person2)(not(has-storage ?place)))
			:effect (has-storage ?place))
			
	(:action buildMine
			:parameters (?person1 ?person2 ?person3 - person ?place - miningResource)
			:precondition (and (is-labourer ?person1) (is-carpenter ?person2) (is-blacksmith ?person3) (at ?person1 ?place) (at ?person2 ?place) (at ?person3 ?place) (has-mineral ?place) (not(has-mine ?place)))
			:effect (has-mine ?place))
			
	(:action buildSmelter
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (not(has-smelter ?place)))
			:effect (has-smelter ?place))
	
	(:action buildQuarry
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (has-mineral ?place) (not(has-quary ?place)))
			:effect (has-quary ?place))
			
	(:action buildSawmill
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (not(has-sawmill ?place)))
			:effect (has-sawmill ?place))
			
	(:action buildRefinery ;;blacksmith
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (not(has-refinery ?place)))
			:effect (has-refinery ?place))
			
	(:action buildMarket
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (not(has-marketStall ?place)))
			:effect (has-marketStall ?place))
			
	;coal/ore	
	(:action mineMinableWithMine
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-miner ?person) (at ?person ?place) (has-mine ?place))
			:effect (got-resource ?person))

	(:action quarryQuarribleStone
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-labourer ?person) (at ?person ?place) (has-quary ?place))
			:effect (got-resource ?person))
)
  