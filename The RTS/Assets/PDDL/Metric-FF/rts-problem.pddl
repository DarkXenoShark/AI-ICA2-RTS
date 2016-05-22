(define (problem rts-prob1)
	(:domain rts)

	(:objects
		PERSONOBJECT - person
		BASEPLAYER_THEGUY1 - person
		BASEPLAYER_THEGUYCASTED - person
		LOCATIONOBJECT - miningResource
		LOCATIONOBJECT1 - miningResource
		LOCATIONOBJECT2 - stone
		LOCATIONOBJECT3 - forest
		LOCATIONOBJECT4 - forest
		LOCATIONOBJECT5 - location
		LOCATIONOBJECT6 - location
		LOCATIONOBJECT7 - location
		)

	(:init
		(is-labourer PERSONOBJECT)
		(at PERSONOBJECT LOCATIONOBJECT)
		(is-labourer BASEPLAYER_THEGUY1)
		(at BASEPLAYER_THEGUY1 LOCATIONOBJECT)
		(is-labourer BASEPLAYER_THEGUYCASTED)
		(at BASEPLAYER_THEGUYCASTED LOCATIONOBJECT)
		(has-coal LOCATIONOBJECT)
		(has-ore LOCATIONOBJECT1)
		(has-stone LOCATIONOBJECT2)
		(has-timber LOCATIONOBJECT3)
		(has-timber LOCATIONOBJECT4)
		(=(labourCost) 0)
		(=(timber) 0)
		(=(wood) 1)
		(=(stone) 0)
		(=(coal) 0)
		(=(ore) 0)
		(=(iron) 0)
		(=(population) 3)
		)

	(:goal
		(and
			(or
				(has-school LOCATIONOBJECT5)
				(has-school LOCATIONOBJECT6)
				(has-school LOCATIONOBJECT7)
			)
			)
		)


)
