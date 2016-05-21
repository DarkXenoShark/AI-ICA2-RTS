(define (problem rts-prob1)
	(:domain rts)

	(:objects
		BasePlayer_TheGuy - person
		BasePlayer_TheGuy1 - person
		BasePlayer_TheGuyCasted - person
		BasePlayer_TheGuyWithAHat - person
		CoalLocation - miningResource
		CoalLocation1 - miningResource
		CoalLocation2 - forest
		CoalLocation3 - stone
		CoalLocation4 - location
		CoalLocation5 - location
		CoalLocation6 - location
		CoalLocation7 - location
		)

	(:init
		(is-labourer BasePlayer_TheGuy)
		(at BasePlayer_TheGuy CoalLocation)
		(is-labourer BasePlayer_TheGuy1)
		(at BasePlayer_TheGuy1 CoalLocation)
		(is-labourer BasePlayer_TheGuyCasted)
		(at BasePlayer_TheGuyCasted CoalLocation)
		(is-labourer BasePlayer_TheGuyWithAHat)
		(at BasePlayer_TheGuyWithAHat CoalLocation)
		(has-coal CoalLocation)
		(has-ore CoalLocation1)
		(has-timber CoalLocation2)
		(has-stone CoalLocation3)
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
			(has-school CoalLocation4)
			)
		)

)
