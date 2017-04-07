// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

// just a test code for Mailbox (use in the REPL)

let actor1 = MailboxProcessor<string>.Start(fun i ->
                async { while true do 
                          let! msg = i.Receive()
                          printf "Got message!!! Message: %s" msg
                })

actor1.Post "Hello world"



// define a list of actors and call them accordingly
let hollywood = 
      [for i in 1 .. 10000 ->
        MailboxProcessor<string>.Start(fun box ->
          async { while true do 
                    let! msg = box.Receive()
                    if i % 1000 = 0 then 
                      printfn "Got message!!! Message from %d : %s" i msg })
      ]


for actor in hollywood do
  actor.Post "I wanto to be a star"