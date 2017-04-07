namespace undoRedo

open Xamarin.Forms
open System.Collections.ObjectModel
open CoreData


module ActorM =
  let undoRedoActor = 
    MailboxProcessor<UndoRedoMsg>.Start(fun inbox ->
      let rec inner (undo: ObservableCollection<ColorInfo>) (redo: ObservableCollection<ColorInfo>) =
        async {
          let! msg = inbox.Receive()
          match msg with 
          | Add m -> undo.Insert(0, m)
          | Redo replyChannel -> 
            if redo.Count > 0 then
              let c = redo.[0]
              undo.Insert(0, c)
              redo.RemoveAt 0
              replyChannel.Reply c
             else
               replyChannel.Reply { Name="White"; Color=Color.White }
          | Undo replyChannel -> 
            if undo.Count > 0 then 
              let c = undo.[0]
              redo.Insert(0, c)
              undo.RemoveAt 0
              replyChannel.Reply c
             else
               replyChannel.Reply { Name="White"; Color=Color.White }

          return! inner undo redo 
        }
      inner coreUndoList coreRedoList 
    )

  // added function to be called to simply post to the actor
  let postAdd colorInfo =
    undoRedoActor.Post(Add colorInfo)

  let postUndo () = 
    undoRedoActor.PostAndReply(fun rc -> Undo rc) 

  let postRedo () = 
    undoRedoActor.PostAndReply(fun rc -> Redo rc) 