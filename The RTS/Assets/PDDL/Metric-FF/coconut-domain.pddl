(define (domain coconut)
  (:requirements :strips :typing)
  
   (:types         
	person - object
	labourer - person
	carpenter - person
	lumberjack - person
	miner - person
	teacher - person
	student - person
	
	location - object
	forest - location	
	
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
	refinery - building ;;blacksmith
	marketstall - building	
	
	
	
	)
	
   (:predicates
		(at ?p - person ?pl - location)
		(at-balloon ?place - location)
		(in-balloon ?person - person)
		(has-coconuts ?pl - location)
		(got-coconuts ?p - person ?pl - location)

		
;;		(my-new-pred ?a ?b ?c ?d - location ?e - person ?f - location)
   )
   
	(:action move
			:parameters (?person - person ?pl-from ?pl-to - location)
			:precondition (and (at ?person ?pl-from))
			:effect (and (at ?person ?pl-to) (not (at ?person ?pl-from))))
	
	(:action cuttree
			:parameters (?person - person ?place - location)
			:precondition (and (in-balloon ?person) (at-balloon ?place) (has-coconuts ?place))
			:effect (and (got-coconuts ?person ?place) (not (has-coconuts ?place))))
	
	(:action board
			:parameters (?person - person ?place - location)
			:precondition (and (at ?person ?place) (at-balloon ?place))
			:effect (and (in-balloon ?person) (not (at ?person ?place))))
			
	(:action depart
			:parameters (?person - person ?place - location)
			:precondition (and (in-balloon ?person) (at-balloon ?place))
			:effect (and (not (in-balloon ?person)) (at ?person ?place)))

	(:action fly
			:parameters (?person - person ?pl-from ?pl-to - location)
			:precondition (and (in-balloon ?person) (at-balloon ?pl-from))
			:effect (and (not (at-balloon ?pl-from)) (at-balloon ?pl-to)))
			


)
  