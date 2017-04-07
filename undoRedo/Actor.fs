namespace undoRedo

type UndoRedoMsg =
  | Undo
  | Redo
  | Add of ColorInfo

module Actor =
  open System.Collections.ObjectModel

  let undoRedoActor = 
    MailboxProcessor<string>.Start(fun inbox ->
      let rec inner (undo: ObservableCollection<ColorInfo>) (redo: ObservableCollection<ColorInfo>) =
        async {
          let! msg = iinbox.Receive()
          match msg with 
          | Add m -> undo.Insert(0, m)
          | Redo -> ()
          | Undo -> ()
          return! inner undo redo 
        }
      loop undo redo 
