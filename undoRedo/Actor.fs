namespace undoRedo


module Actor =
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
      loop coreData.undoList coreData.redoList 

  let postAdd colorInfo =
    undoRedoActor.Post(Add colorInfo)