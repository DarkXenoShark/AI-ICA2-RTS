(define (problem rts-prob1)
	(:domain rts)

	(:objects
		Test - person
		Guy - person
		TheGuy - person
		OfficerGuy - person
		Tree1 - forest
		Tree2 - forest
		Coal1 - miningResource
		Coal2 - miningResource
		Location1 - location
		Location2 - location
		Location3 - location
		OreLocation - miningResource
		StoneLocation - stone
		)

	(:init
		(is-labourer Test)
		(at Test Location3)
		(is-labourer Guy)
		(at Guy Location1)
		(is-labourer TheGuy)
		(at TheGuy Location1)
		(is-labourer OfficerGuy)
		(at OfficerGuy Location1)
		(has-timber Tree1)
		(has-timber Tree2)
		(has-coal Coal1)
		(has-coalMine Coal2)
		(has-coal Coal2)
		(has-turfhut Location1)
		(has-ore OreLocation)
		(has-stone StoneLocation)
		(=(labourCost) 0)
		(=(timber) 0)
		(=(wood) 0)
		(=(stone) 0)
		(=(coal) 0)
		(=(ore) 0)
		(=(iron) 0)
		(=(population) 4)
		)

	(:goal
		(and
			(has-school Location2)
			)
		)

)
