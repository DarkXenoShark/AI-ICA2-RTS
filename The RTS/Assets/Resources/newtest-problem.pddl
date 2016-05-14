(define (problem newtest-prob1)
	(:domain newtest)

	(:objects
		Labourer0 - person
		Labourer1 - person
		Labourer3 - person
		Building0 - location
		Building1 - location
		Building2 - location
		Building3 - location
		Building5 - location
		Building6 - location
		)

	(:init
		(is-carpenter Labourer0)
		(at Labourer0 )
		(is-errorjob Labourer1)
		(at Labourer1 )
		(is-carpenter Labourer3)
		(at Labourer3 Building0)
		(has-sawmill Building0)
		(has-refinery Building1)
		(has-sawmill Building2)
		(has-errorbuilding Building3)
		(has-sawmill Building5)
		(has-marketStall Building6)
		)

	(:goal
		)

)
