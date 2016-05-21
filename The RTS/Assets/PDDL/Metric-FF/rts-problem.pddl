(define (problem rts-prob1)
	(:domain rts)

	(:objects
		BASEPLAYER_THEGUY - person
		BASEPLAYER_THEGUY1 - person
		BASEPLAYER_THEGUYCASTED - person
		BASEPLAYER_THEGUYWITHAHAT - person
		COALLOCATION - miningResource
		COALLOCATION1 - miningResource
		COALLOCATION2 - forest
		COALLOCATION3 - stone
		COALLOCATION4 - location
		COALLOCATION5 - location
		COALLOCATION6 - location
		COALLOCATION7 - location
		)

	(:init
		(is-labourer BASEPLAYER_THEGUY)
		(at BASEPLAYER_THEGUY CoalLocation)
		(is-labourer BASEPLAYER_THEGUY1)
		(at BASEPLAYER_THEGUY1 CoalLocation)
		(is-labourer BASEPLAYER_THEGUYCASTED)
		(at BASEPLAYER_THEGUYCASTED CoalLocation)
		(is-labourer BASEPLAYER_THEGUYWITHAHAT)
		(at BASEPLAYER_THEGUYWITHAHAT CoalLocation)
		(has-coal COALLOCATION)
		(has-ore COALLOCATION1)
		(has-timber COALLOCATION2)
		(has-stone COALLOCATION3)
		(=(labourCost) 0)
		(=(timber) 0)
		(=(wood) 2)
		(=(stone) 0)
		(=(coal) 0)
		(=(ore) 0)
		(=(iron) 0)
		(=(population) 4)
		)

	(:goal
		(and
			(has-storage COALLOCATION4)
			)
		)

)
