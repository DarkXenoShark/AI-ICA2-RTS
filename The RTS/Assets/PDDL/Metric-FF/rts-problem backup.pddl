(define (problem rts-prob1)
  (:domain rts)
  	
  (:objects
	labourer0 - person
	labourer1 - person
	labourer2 - person
	
	tree1 tree2 tree3 tree4 - forest
	stone1 - stone
	locationOre1 locationCoal1 - miningResource
	
	location1 location2 location3 - location)

  (:init 	
			(is-labourer labourer0)
			(is-labourer labourer1)
			(is-labourer labourer2)
			(has-timber tree1)
			(has-timber tree2)
			(has-timber tree3)
			(has-timber tree4)
			(at labourer0 tree2)
			(at labourer1 tree1)
			(at labourer2 tree1)
			(has-stone stone1)
			(has-ore locationOre1)
			(has-coal locationCoal1)
			(=(labourCost) 0)
			(=(timber) 0)
			(=(wood) 0)
			(=(stone) 0)
			(=(coal) 0)
			(=(ore) 0)
			(=(iron) 0)
			(=(population)0)
	)
  
  (:goal 	
  ;; dont forget the (and ) block to enclose everything together
		(and
			;(=(population)5)
			(has-school location1)
			)
	)
	
	;(:metric minimize (labourCost))
)
