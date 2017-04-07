namespace undoRedo

open Xamarin.Forms
open System.Collections.ObjectModel

type ColorInfo = {
  Name : string
  Color: Color
}

type UndoRedoMsg =
  | Undo of AsyncReplyChannel<ColorInfo>
  | Redo of AsyncReplyChannel<ColorInfo>
  | Add of ColorInfo


module CoreData =
  let coreUndoList = new ObservableCollection<ColorInfo>()
  let coreRedoList = new ObservableCollection<ColorInfo>()
