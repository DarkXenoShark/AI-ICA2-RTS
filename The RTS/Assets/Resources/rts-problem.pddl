(define (problem rts-prob1)
	(:domain rts)

	(:objects
		Test - person
		Bob - person
		Charlie - person
		Tree1 - timber
		Tree2 - timber
		Coal1 - coal
		Coal2 - coal
		Location1 - location
		Location2 - location
		Location3 - location
		)

	(:init
		(is-labourer Test)
		(at Test Location3)
		(is-labourer Bob)
		(at Bob Location1)
		(is-miner Charlie)
		(at Charlie Coal)
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
		(=(population) 3)
		)

	(:goal
		(and
		(has-school Location2)
		)

)
