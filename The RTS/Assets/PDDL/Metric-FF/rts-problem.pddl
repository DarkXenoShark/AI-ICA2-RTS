(define (problem rts-prob1)
  (:domain rts)
  	
  (:objects
	labourer0 - person
	labourer1 - person
	labourer2 - person
	
	tree1 tree2 - forest)

  (:init 	
			(is-lumberjack labourer0)
			(has-wood tree1)
			;(is-carpenter labourer1)
			;(is-blacksmith labourer2)
			(at labourer0 tree2)
			;(at labourer2 tree1)
			;(at labourer2 tree1)
	)
  
  (:goal 	
  ;; dont forget the (and ) block to enclose everything together
		(and
			(got-wood labourer0 tree1) 
			;(got-mine tree2) 
			)
	)
)
