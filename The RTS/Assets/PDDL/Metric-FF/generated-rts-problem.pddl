(define (problem generated-rts-prob1)
	(:domain generated-rts)

	(:objects
		Test - person
		Guy - person
		MikeHaggar - person
		Cody - person
		Tree1 - forest
		Tree2 - forest
		Coal1 - miningResource
		Coal2 - miningResource
		Location1 - location
		Location2 - location
		Location3 - location
		)

	(:init
		(is-labourer Test)
		(at Test Location3)
		(is-labourer Guy)
		(at Guy Location1)
		(is-errorjob MikeHaggar)
		(at MikeHaggar Tree2)
		(is-miner Cody)
		(at Cody Coal)
		(has-timber Tree1)
		(has-timber Tree2)
		(has-coal Coal1)
		(has-coalMine Coal2)
		(has-coal Coal2)
		(has-turfhut Location1)
		(=(labourCost) 0)
		(=(timber) 2)
		(=(wood) 8)
		(=(stone) 1)
		(=(coal) 0)
		(=(ore) 5)
		(=(iron) 6)
		(=(population) 4)
		)

	(:goal
		(and
		(has-school Location2)
		)

)
