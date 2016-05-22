(define (problem rts-prob1)
	(:domain rts)

	(:objects
		PERSONOBJECT - person
		BASEPLAYER_THEGUY1 - person
		BASEPLAYER_THEGUYCASTED - person
		LOCATIONOBJECT - miningResource
		LOCATIONOBJECT1 - forest
		LOCATIONOBJECT2 - miningResource
		LOCATIONOBJECT3 - forest
		LOCATIONOBJECT4 - location
		LOCATIONOBJECT5 - stone
		LOCATIONOBJECT6 - location
		LOCATIONOBJECT7 - location
		LOCATIONOBJECT8 - location
		LOCATIONOBJECT9 - stone
		LOCATIONOBJECT10 - stone
		LOCATIONOBJECT11 - forest
		LOCATIONOBJECT12 - miningResource
		LOCATIONOBJECT13 - forest
		LOCATIONOBJECT14 - location
		)

	(:init
		(is-labourer PERSONOBJECT)
		(at PERSONOBJECT LOCATIONOBJECT4)
		(is-labourer BASEPLAYER_THEGUY1)
		(at BASEPLAYER_THEGUY1 LOCATIONOBJECT4)
		(is-labourer BASEPLAYER_THEGUYCASTED)
		(at BASEPLAYER_THEGUYCASTED LOCATIONOBJECT4)
		(has-coal LOCATIONOBJECT)
		(has-timber LOCATIONOBJECT1)
		(has-ore LOCATIONOBJECT2)
		(has-timber LOCATIONOBJECT3)
		(has-stone LOCATIONOBJECT5)
		(has-stone LOCATIONOBJECT9)
		(has-stone LOCATIONOBJECT10)
		(has-timber LOCATIONOBJECT11)
		(has-ore LOCATIONOBJECT12)
		(has-timber LOCATIONOBJECT13)
		(=(labourCost) 0)
		(=(timber) 0)
		(=(wood) 0)
		(=(stone) 0)
		(=(coal) 0)
		(=(ore) 0)
		(=(iron) 0)
		(=(population) 3)
		)

	(:goal
		(and
			(has-school LOCATIONOBJECT4)
			)
		)

		(:metric minimize (labourCost))

)
