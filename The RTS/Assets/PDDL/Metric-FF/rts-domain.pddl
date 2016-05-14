(define (domain rts)
  (:requirements :strips :typing)
  
   (:types         
	person - object
   ; labourer - person
	;carpenter - person
	;lumberjack - person
	;miner - person
	;teacher - person
	;student - person
	
	location - object
	forest - location	
	miningResource - location
	stone - location
	building - location
	
	turfhut - building
	house - building
	school - building
	barracks - building
	storeageunity - building ;;storage
	mine - building
	smelter - building
	quarry - building
	sawmill - building
	refinery - building ;;
	marketstall - building	
	
	
	
	)
	
   (:predicates
		
		(at ?p - person ?pl - location)
		(is-person ?person - person)
		(is-labourer ?person - person)
		(is-carpenter ?person - person)
		(is-lumberjack ?person - person)
		(is-miner ?person - person)
		(is-blacksmith ?person - person)
		
		
		(has-wood ?pl - location)
		(has-mine ?pl - location)
		(has-mineral ?pl - location)
		(has-turfhut ?pl - location)
		(has-house ?pl - location)
		(has-quary ?pl -location)
		
		;;----------------------------------;;
		
		(has-skill ?p - person)
		
		
		(got-wood ?p - person ?pl - location)
		(got-mineral ?p - person ?pl - location)
		(got-baby ?p1 - person ?p2 - person)
		
		
		;;----------------------------------;;
		
		(at-balloon ?place - location)
		(in-balloon ?person - person)
		(has-coconuts ?pl - location)
		(got-coconuts ?p - person ?pl - location)

		
;;		(my-new-pred ?a ?b ?c ?d - location ?e - person ?f - location)
   )
   
   	(:action buildTurfHut
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (is-labourer person) (not (has-turfhut)))
			:effect (has-turfhut ?location))
			
	(:action buildHouse
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (is-labourer person) (not (has-house)))
			:effect (has-house ?location))
			
	(:action multiply
			:parameters (?person1 - person ?person2 - person ?location - location)
			:precondition (and (at ?person1 ?location) (at ?person2 ?location) (not (has-house)))
			:effect (got-baby ?person1 ?person2))
   
  	(:action simpletrain
			:parameters (?teacher - person ?student - person ?location - location)
			:precondition (and (at ?teacher ?location) (at ?student ?location) (not (has-skill ?student)))
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
			
			
	;;train teacher
	
	
	(:action move
			:parameters (?person - person ?pl-from ?pl-to - location)
			:precondition (and (at ?person ?pl-from))
			:effect (and (at ?person ?pl-to) (not (at ?person ?pl-from))))
			
	(:action cuttree
			:parameters (?person - person ?place - forest)
			:precondition (and (is-lumberjack ?person)(at ?person ?place) (has-wood ?place) (not(got-wood ?person ?place)))
			:effect (and (got-wood ?person ?place) (not (has-wood ?place))))
	
	(:action buildMine
			:parameters (?person1 ?person2 ?person3 - person ?place - miningResource)
			:precondition (and (is-labourer ?person1) (is-carpenter ?person2) (is-blacksmith ?person3) (at ?person1 ?place) (at ?person2 ?place) (at ?person3 ?place) (not(has-mine ?place)))
			:effect (has-mine ?place))
			
	(:action buildQuarry
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person1) (not(has-quary ?place)))
			:effect (has-quary ?place))
			
			
	;coal/stone/iron	
	(:action mineResourceWithMine
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-miner ?person) (at ?person ?place) (has-mine ?place))
			:effect ((got-mineral ?person ?place)))


)
  