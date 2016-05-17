(define (problem rts-prob1)
  (:domain rts)
  	
  (:objects
	labourer0 - person
	labourer1 - person
	labourer2 - person
	
	tree1 tree2 - forest
	stone1 - stone
	locationOre1 locationCoal1 - miningResource
	
	location1 location2 location3 - location)

  (:init 	
			(is-labourer labourer0)
			(is-labourer labourer1)
			(has-timber tree1)
			(at labourer0 tree2)
			(at labourer1 tree1)
			(at labourer2 tree1)
			(has-stone stone1)
			(has-ore locationOre1)
			(has-coal locationCoal1)
			(=(labourCost) 0)
	)
  
  (:goal 	
  ;; dont forget the (and ) block to enclose everything together
		(and
			(has-storage location1) 
			;(got-baby labourer0 labourer1)
			;(got-mine tree2) 
			)
	)
)
