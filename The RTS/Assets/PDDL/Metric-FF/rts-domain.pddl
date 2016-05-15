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
		
		(has-timber ?pl - location)
		(has-coal ?pl - location)
		(has-ore ?pl - location)
		(has-stone ?pl - location)
		
		(has-turfhut ?pl - location)
		(has-house ?pl - location)
		(has-school ?pl -location)
		(has-barracks ?pl -location)
		(has-storage ?pl -location)
		(has-coalMine ?pl - location)
		(has-oreMine ?pl - location)
		(has-smelter ?pl -location)
		(has-quary ?pl -location)
		(has-sawmill ?pl - location)
		(has-refinery ?pl - location) ;;blacksmith
		(has-marketStall ?pl - location)
		
		;;----------------------------------;;
		
		(has-skill ?p - person)
		(has-riflemanSkill ?p - person)
		
		(got-timber ?p - person)
		(got-wood ?p - person)
		(got-stone ?p - person)
		(got-ore ?p - person)
		(got-iron ?p - person)
		(got-coal ?p - person)
				
		(got-swood ?pl - location)
		(got-stimber ?pl - location)
		(got-sstone ?pl - location)
		(got-sore ?pl - location)
		(got-siron ?pl - location)
		(got-scoal ?pl - location)
		
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
			:parameters (?teacher - person ?student - person ?place - building)
			:precondition (and (at ?teacher ?place) (at ?student ?place) (is-teacher ?teacher) (has-school ?place) (not (has-skill ?student)))
			:effect (has-skill ?student))
	
	(:action trainCarpenter
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-carpenter ?person)))
			:effect (and(is-carpenter ?person)(not(has-skill ?person))))
	
	(:action trainLumberjack
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-lumberjack ?person)))
			:effect (and(is-lumberjack ?person)(not(has-skill ?person))))
			
	(:action trainMiner
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-miner ?person)))
			:effect (and(is-miner ?person)(not(has-skill ?person))))
			
	(:action trainBlacksmith
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-blacksmith ?person)))
			:effect (and(is-blacksmith ?person)(not(has-skill ?person))))
			
	(:action trainTeacher
			:parameters (?person - person)
			:precondition(and (has-skill ?person) (not (is-teacher ?person)))
			:effect (and(is-teacher ?person) (not(has-skill ?person))))
	
	(:action trainRifleman
			:parameters (?person - person ?place - building)
			:precondition(and (has-skill ?person) (has-barracks ?place) (not (has-riflemanSkill ?person)))
			:effect (and(has-riflemanSkill ?person)(not(has-skill ?person))))
	
	
	
	;;--------------------------------------;;
	
	

	(:action move
			:parameters (?person - person ?pl-from ?pl-to - location)
			:precondition (and (at ?person ?pl-from))
			:effect (and (at ?person ?pl-to) (not (at ?person ?pl-from))))
			
	(:action cuttree
			:parameters (?person - person ?place - forest)
			:precondition (and (is-lumberjack ?person)(at ?person ?place) (has-timber ?place))
			:effect (and (got-timber ?person) (not (has-timber ?place))))

	(:action multiplySingle
			:parameters (?person1 - person ?person2 - person ?place - location)
			:precondition (and (at ?person1 ?place) (at ?person2 ?place) )
			:effect (got-baby ?person1 ?person2))
			
	(:action multiplyDouble
			:parameters (?person1 - person ?person2 - person ?place - location)
			:precondition (and (at ?person1 ?place) (at ?person2 ?place) )
			:effect (got-baby ?person1 ?person2))		
	
	(:action storeWood
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (got-wood ?person) (has-storage ?place))
			:effect (and(got-swood ?place)(not (got-wood ?person))))
			
	(:action storeTimber
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (got-timber ?person) (has-storage ?place))
			:effect (and(got-stimber ?place)(not (got-timber ?person))))
	
	(:action storeStone
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (got-stone ?person) (has-storage ?place))
			:effect (and(got-sstone ?place)(not (got-stone ?person))))
			
	(:action storeOre
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (got-ore ?person) (has-storage ?place))
			:effect (and(got-sore ?place)(not (got-ore ?person))))
			
	(:action storeIron
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (got-iron ?person) (has-storage ?place))
			:effect (and(got-siron ?place)(not (got-iron ?person))))
			
	(:action sawTimberatSawmill
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (has-sawmill ?place) (is-labourer ?person) (got-timber ?person))
			:effect (and (got-wood ?person)(not (got-timber ?person))))
			
	(:action smeltOreatSmelter
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (has-smelter ?place) (is-labourer ?person) (got-ore ?person) (got-coal ?person))
			:effect (and (got-iron ?person)(not (got-ore ?person))(not (got-coal ?person))))
	
	;;do need different types of mineral 
	
	;;----------------Buildings-----------------;;
	
	
	
   	(:action buildTurfHut
			:parameters (?person - person ?place - building)
			:precondition (and (at ?person ?place) (is-labourer ?person) (not (has-turfhut ?place)))
			:effect (has-turfhut ?place))
			
	(:action buildHouse
			:parameters (?person1 - person ?person2 - person ?place - building)
			:precondition (and (at ?person1 ?place)(at ?person2 ?place) (is-carpenter ?person1) (is-labourer ?person2) 
						 (or (got-wood ?person1) (got-wood ?person2))
						 (or (got-stone ?person1) (got-stone ?person2))
						 (not (got-house ?place)))
			:effect (has-house ?place))
			
	(:action buildSchool
			:parameters (?person1 - person ?person2 - person ?place - building)
			:precondition (and (at ?person1 ?place)(at ?person2 ?place) (is-carpenter ?person1)(is-labourer ?person2)
						 (or (got-wood ?person1) (got-wood ?person2))
						 (or (got-stone ?person1) (got-stone ?person2))
						 (or (got-iron ?person1) (got-iron ?person2))
						 (not(has-school ?place)))
			:effect (has-school ?place))
			
	(:action buildBarracks
			:parameters (?person1 - person ?person2 - person ?place - building)
			:precondition (and (at ?person1 ?place)(at ?person2 ?place) (is-carpenter ?person1)(is-labourer ?person2)
						 (or (got-wood ?person1) (got-wood ?person2))
						 (or (got-stone ?person1) (got-stone ?person2))
						 (not(has-barracks ?place)))
			:effect (has-barracks ?place))
			
	(:action buildStorage
			:parameters (?person1 - person ?person2 - person ?place - building)
			:precondition (and (at ?person1 ?place)(at ?person2 ?place) (is-carpenter ?person1)(is-labourer ?person2)
						 (or (got-wood ?person1) (got-wood ?person2))
						 (or (got-stone ?person1) (got-stone ?person2))
						 (not(has-storage ?place)))
			:effect (has-storage ?place))
			
	(:action buildCoalMine
			:parameters (?person1 ?person2 ?person3 - person ?place - miningResource)
			:precondition (and (is-labourer ?person1) (is-carpenter ?person2) (is-blacksmith ?person3) (at ?person1 ?place) (at ?person2 ?place) (at ?person3 ?place) (has-coal ?place)
						 (or (got-wood ?person1) (got-wood ?person2) (got-wood ?person3))
						 (or (got-iron ?person1) (got-iron ?person2) (got-iron ?person3))
						 (not(has-coalMine ?place)))
			:effect (has-coalMine ?place))
			
	(:action buildOreMine
			:parameters (?person1 ?person2 ?person3 - person ?place - miningResource)
			:precondition (and (is-labourer ?person1) (is-carpenter ?person2) (is-blacksmith ?person3) (at ?person1 ?place) (at ?person2 ?place) (at ?person3 ?place) (has-ore ?place) 
						 (or (got-wood ?person1) (got-wood ?person2) (got-wood ?person3))
						 (or (got-iron ?person1) (got-iron ?person2) (got-iron ?person3))
						 (not(has-oreMine ?place)))
			:effect (has-oreMine ?place))
			
	(:action buildSmelter
			:parameters (?person - person ?location - location)
			:precondition (and (is-labourer ?person) (got-stone ?person) (not(has-smelter ?location)))
			:effect (has-smelter ?location))
	
	(:action buildQuarry
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (has-stone ?place) (not(has-quary ?place)))
			:effect (has-quary ?place))
			
	(:action buildSawmill
			:parameters (?person - person ?location - location)
			:precondition (and (is-labourer ?person) (got-stone ?person) (got-iron ?person) (got-timber ?person) (not(has-sawmill ?location)))
			:effect (has-sawmill ?location))
			
	(:action buildRefinery ;;blacksmith
			:parameters (?person - person ?location - location)
			:precondition (and (is-labourer ?person) (got-stone ?person) (got-iron ?person) (got-timber ?person) (not(has-refinery ?location)))
			:effect (has-refinery ?location))
			
	(:action buildMarket
			:parameters (?person - person ?location - location)
			:precondition (and (is-labourer ?person) (got-wood ?person)(not(has-marketStall ?location)))
			:effect (has-marketStall ?location))
			
	;coal/ore	
	(:action mineMinableWithMineOre
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-miner ?person) (at ?person ?place) (has-oreMine ?place))
			:effect (got-ore ?person))
			
	(:action mineMinableWithMineCoal
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-miner ?person) (at ?person ?place) (has-coalMine ?place))
			:effect (got-coal ?person))

	(:action quarryQuarribleStone
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (at ?person ?place) (has-quary ?place))
			:effect (got-stone ?person))
)
  