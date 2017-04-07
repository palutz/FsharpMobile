namespace undoRed

open Xamarin.Forms
open System.Collections.ObjectModel

type ColorInfo = {
  Name : string
  Color: Color
}

type UndoRedoMsg =
  | Undo
  | Redo
  | Add of ColorInfo


module coreData =
  let undoList = new ObservableCollection<ColorInfo>()
  let redoList = new ObservableCollection<ColorInfo>()
