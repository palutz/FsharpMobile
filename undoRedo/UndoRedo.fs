namespace undoRedo

open Xamarin.Forms
open Xamarin.Forms.Xaml
open System
open System.Collections.ObjectModel
open CoreData
open ActorM


type UndoRedoPage() =
  inherit ContentPage()

  // access the xaml code to access the xaml code from here (fs code)
  // (we ignore the result, the page loaded, we nned only the side effect ( :( )
  // let _ = base.LoadFromXaml(typeof<UndoRedoPage>) the same of the |> igonre 
  do base.LoadFromXaml(typeof<UndoRedoPage>) |> ignore

  let helloLabel = base.FindByName<Label>("helloLabel")
  let redoList = base.FindByName<ListView>("redoLV")
  let undoList = base.FindByName<ListView>("undoLV")

  do 
    // init items
    helloLabel.BackgroundColor <- Color.Red
    redoList.ItemsSource <- coreRedoList
    undoList.ItemsSource <- coreUndoList
  
  member __.OnButtonRedClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Red
    postAdd { Name="Red"; Color=Color.Red }
  
  member __.OnButtonFuchsiaClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Fuchsia
    postAdd { Name="Fuchsia"; Color=Color.Fuchsia }

  member __.OnButtonGreenClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Green
    postAdd {  Name="Green"; Color=Color.Green }

  member __.OnButtonYellowClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Yellow
    postAdd {  Name="Yellow"; Color=Color.Yellow }

  member __.OnBtnUndoClicked (sender:Object) (args:EventArgs) =
    let undoColor = postUndo()
    helloLabel.BackgroundColor <- undoColor

  member __.OnBtnRedoClicked (sender:Object) (args:EventArgs) =
    let redoColor = postRedo()
    helloLabel.BackgroundColor <- redoColor
  

type App() =
  inherit Application(MainPage = UndoRedoPage())   // hooking the app to our main page

 