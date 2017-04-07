namespace undoRedo

open Xamarin.Forms
open Xamarin.Forms.Xaml
open System

type UndoRedoPage() =
  inherit ContentPage()

  // access the xaml code to access the xaml code from here (fs code)
  // (we ignore the result, the page loaded, we nned only the side effect ( :( )
  // let _ = base.LoadFromXaml(typeof<UndoRedoPage>) the same of the |> igonre 
  do base.LoadFromXaml(typeof<UndoRedoPage>) |> ignore

  let helloLabel = base.FindByName<Label>("helloLabel")

  do 
    helloLabel.BackgroundColor <- Color.Red
  
  
  member __.OnButtonRedClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Red

  member __.OnButtonFuchsiaClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Fuchsia

  member __.OnButtonGreenClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Green

  member __.OnButtonYellowClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Yellow
  

type App() =
  inherit Application(MainPage = UndoRedoPage())   // hooking the app to our main page

 