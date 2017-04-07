namespace undoRedo

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
          | Redo -> ()
          | Undo -> ()
          return! inner undo redo 
        }
      inner coreUndoList coreRedoList 
    )

  // added function to be called to simply post to the actor
  let postAdd colorInfo =
    undoRedoActor.Post(Add colorInfo)