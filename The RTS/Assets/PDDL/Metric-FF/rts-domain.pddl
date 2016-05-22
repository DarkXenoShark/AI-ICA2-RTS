(define (domain rts)
  (:requirements :strips :typing :fluents)
  
   (:types         
	person - object
	
	location - object
	forest - location	
	miningResource - location
	stone - location
	)
	
	(:functions
		(labourCost)
		(timber)
		(wood)
		(stone)
		(ore)
		(coal)
		(iron)
		(population)
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
		
		(has-building ?pl - location)
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
			:precondition (and (at ?teacher ?location) (at ?student ?location) (not (has-skill ?student))(not(= ?teacher ?student)))
			:effect (and(has-skill ?student) (increase (labourCost) 100)))
			
	(:action schooltrain
			:parameters (?teacher - person ?student - person ?place - location)
			:precondition (and (at ?teacher ?place) (at ?student ?place) (is-teacher ?teacher) (has-school ?place) (not (has-skill ?student))(not(= ?teacher ?student)))
			:effect (and(has-skill ?student)(increase (labourCost) 50)))
	
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
			:parameters (?person - person ?place - location)
			:precondition(and (has-skill ?person) (has-barracks ?place) (not (has-riflemanSkill ?person)))
			:effect (and(has-riflemanSkill ?person)(not(has-skill ?person))(increase (labourCost) 30)))
	
	
	
	;;--------------------------------------;;
	
	

	(:action move
			:parameters (?person - person ?pl-from ?pl-to - location)
			:precondition (and (at ?person ?pl-from))
			:effect (and (at ?person ?pl-to) (not (at ?person ?pl-from))))
			
	;coal/ore	
	
	(:action cuttree
			:parameters (?person - person ?place - forest)
			:precondition (and (is-lumberjack ?person)(at ?person ?place) (has-timber ?place))
			:effect (and (got-timber ?person) (not (has-timber ?place))(increase (labourCost) 5)))
	
	(:action simpleMineOre
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-labourer ?person)(at ?person ?place) (has-ore ?place) (not(got-ore ?person)))
			:effect (and (got-ore ?person)(increase (labourCost) 100)))	
			
	(:action simpleMineCoal
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-labourer ?person)(at ?person ?place) (has-coal ?place) (not(got-coal ?person)))
			:effect (and (got-coal ?person)(increase (labourCost) 100)))
			
	(:action mineOreWithMine
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-miner ?person) (at ?person ?place) (has-oreMine ?place))
			:effect (and(got-ore ?person)(increase (labourCost) 25)))
			
	(:action mineCoalWithMine
			:parameters (?person - person ?place - miningResource)
			:precondition (and (is-miner ?person) (at ?person ?place) (has-coalMine ?place))
			:effect (and(got-coal ?person)(increase (labourCost) 25)))

	(:action QuarryStone
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (at ?person ?place) (has-quary ?place))
			:effect (and(got-stone ?person)(increase (labourCost) 25)))
			
	(:action sawTimberatSawmill
			:parameters (?person - person ?place - location)
			:precondition (and (at ?person ?place) (has-sawmill ?place) (is-labourer ?person) (got-timber ?person))
			:effect (and (got-wood ?person)(not (got-timber ?person))(increase (labourCost) 50)))
			
	(:action smeltOreatSmelter
			:parameters (?person - person ?place - location)
			:precondition (and (at ?person ?place) (has-smelter ?place) (is-labourer ?person) (got-ore ?person) (got-coal ?person))
			:effect (and (got-iron ?person)(not (got-ore ?person))(not (got-coal ?person))(increase (labourCost) 50)))

			
	(:action multiplySingle
			:parameters (?person1 - person ?person2 - person ?location - location)
			:precondition (and (at ?person1 ?location) (at ?person2 ?location) (has-turfhut ?location) (not(= ?person1 ?person2)))
			:effect (and(got-baby ?person1 ?person2)(increase (labourCost) 10)(increase (population) 1)))
			
	(:action multiplyDouble
			:parameters (?person1 - person ?person2 - person ?location - location)
			:precondition (and (at ?person1 ?location) (at ?person2 ?location) (has-house ?location)(not(= ?person1 ?person2)))
			:effect (and(got-baby ?person1 ?person2)(increase (labourCost) 50)(increase (population) 2)))
	
	(:action storeTimber
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (got-timber ?person) (has-storage ?location))
			:effect (and(got-stimber ?location)(not (got-timber ?person))(increase (timber) 1)))
	
	(:action storeWood
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (got-wood ?person) (has-storage ?location))
			:effect (and(got-swood ?location)(not (got-wood ?person))(increase (wood) 1)))
	
	(:action storeStone
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (got-stone ?person) (has-storage ?location))
			:effect (and(got-sstone ?location)(not (got-stone ?person))(increase (stone) 1)))
			
	(:action storeOre
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (got-ore ?person) (has-storage ?location))
			:effect (and(got-sore ?location)(not (got-ore ?person))(increase (ore) 1)))
			
	(:action storeCoal
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (got-coal ?person) (has-storage ?location))
			:effect (and(got-scoal ?location)(not (got-coal ?person))(increase (coal) 1)))
			
	(:action storeIron
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (got-iron ?person) (has-storage ?location))
			:effect (and(got-siron ?location)(not (got-iron ?person))(increase (iron) 1)))
			

	
	;;do need different types of mineral 
	
	;;----------------Buildings-----------------;;
	
	
	
   	(:action buildTurfHut
			:parameters (?person - person ?location - location)
			:precondition (and (at ?person ?location) (is-labourer ?person) (not (has-turfhut ?location)) (not (has-building ?location)))
			:effect (and (has-turfhut ?location) (has-building ?location)(increase (labourCost) 10)))
			
	(:action buildHouse
			:parameters (?person1 ?person2 - person ?location - location)
			:precondition (and (at ?person1 ?location)(at ?person2 ?location) (is-carpenter ?person1) (is-labourer ?person2) 
						 (>= (wood)1) (>= (stone)1)
						 (not (has-building ?location))(not(= ?person1 ?person2)))
			:effect (and(has-building ?location)(has-house ?location)
					(increase (labourCost) 15)(decrease (wood) 1)(decrease (stone) 1)))
			
	(:action buildSchool
			:parameters (?person1 ?person2 - person  ?location - location)
			:precondition (and (at ?person1 ?location)(at ?person2 ?location) (is-carpenter ?person1)(is-labourer ?person2)
						 (>= (wood)1) (>= (stone)1) (>= (iron)1)
						 (not (has-building ?location))(not(= ?person1 ?person2)))
			:effect (and(has-building ?location)(has-school ?location)
				    (increase (labourCost) 30)(decrease (wood) 1)(decrease (stone) 1)))
			
	(:action buildBarracks
			:parameters (?person1 ?person2 - person ?location - location)
			:precondition (and (at ?person1 ?location)(at ?person2 ?location) (is-carpenter ?person1)(is-labourer ?person2)
						 (>= (wood)1) (>= (stone)1)
						 (not (has-building ?location))(not(= ?person1 ?person2)))
			:effect (and (has-building ?location)(has-barracks ?location)
					(increase (labourCost) 30)(decrease (wood) 1)(decrease (stone) 1)))
			
	(:action buildStorage
			:parameters (?person1 - person ?person2 - person ?location - location)
			:precondition (and (at ?person1 ?location)(at ?person2 ?location) (is-carpenter ?person1)(is-labourer ?person2)
						 (or(got-timber ?person1)(got-timber ?person2))
						 (or(got-stone ?person1)(got-stone ?person2))
						 (not (has-building ?location))(not(= ?person1 ?person2)))
			:effect (and (has-building ?location)(has-storage ?location)
					(not(got-wood ?person1))(not(got-wood ?person2))
					(not(got-stone ?person1))(not(got-stone ?person2))))
			
	(:action buildCoalMine
			:parameters (?person1 ?person2 ?person3 - person ?place - miningResource)
			:precondition (and (is-labourer ?person1) (is-carpenter ?person2) (is-blacksmith ?person3) (at ?person1 ?place) (at ?person2 ?place) (at ?person3 ?place) (has-coal ?place)
						 (>= (wood)1) (>= (iron)1)
						 (not (has-building ?place))(not(= ?person1 ?person2)))
			:effect (and (has-building ?place)(has-coalMine ?place)
					(increase (labourCost) 25)(decrease (wood) 1)(decrease (iron) 1)))
			
	(:action buildOreMine
			:parameters (?person1 ?person2 ?person3 - person ?place - miningResource)
			:precondition (and (is-labourer ?person1) (is-carpenter ?person2) (is-blacksmith ?person3) (at ?person1 ?place) (at ?person2 ?place) (at ?person3 ?place) 
						 (>= (wood)1) (>= (iron)1)
						 (not (has-building ?place))(not(= ?person1 ?person2)))
			:effect (and (has-building ?place)(has-oreMine ?place)
					(increase (labourCost) 25)(decrease (wood) 1)(decrease (iron) 1)))
			
	(:action buildSmelter
			:parameters (?person - person ?location - location)
			:precondition (and (is-labourer ?person) (>=(stone)1) (at ?person ?location) (not (has-building ?location)))
			:effect (and (has-building ?location)(has-smelter ?location)(increase (labourCost) 20)(decrease (stone) 1)))
	
	(:action buildQuarry
			:parameters (?person - person ?place - stone)
			:precondition (and (is-labourer ?person) (at ?person ?place) (has-stone ?place) (not (has-building ?place)))
			:effect (and (has-building ?place)(has-quary ?place)(increase (labourCost) 10)))
			
	(:action buildSawmill
			:parameters (?person - person ?location - location)
			:precondition (and (is-labourer ?person) (>=(stone)1) (>= (iron)1)(>= (timber)1) (at ?person ?location) (not (has-building ?location)))
			:effect (and (has-building ?location)(has-sawmill ?location)
					(decrease (stone) 1)(decrease (iron) 1)(decrease (timber) 1)(increase (labourCost) 10)))
			
	(:action buildRefinery ;;blacksmith
			:parameters (?person - person ?location - location)
			:precondition (and (is-labourer ?person) (at ?person ?location)(>=(stone)1) (>= (iron)1)(>= (timber)1)(not (has-building ?location)))
			:effect (and (has-building ?location)(has-refinery ?location)
					(decrease (stone) 1)(decrease (iron) 1)(decrease (timber) 1)(increase (labourCost) 10) ))
			
	;(:action buildMarket
		;	:parameters (?person - person ?location - location)
			;:precondition (and (is-labourer ?person) (got-wood ?person) (at ?person ?location)(not(has-marketStall ?location))(not (has-building ?location)))
			;:effect (and (has-building ?location)(has-marketStall ?location)
			;		(not(got-wood ?person))))
			
	)
  