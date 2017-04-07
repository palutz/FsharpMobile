namespace undoRedo

open Xamarin.Forms
open Xamarin.Forms.Xaml
open System
open System.Collections.ObjectModel



type ColorInfo = {
  Name : string
  Color: Color
}


type UndoRedoPage() =
  inherit ContentPage()

  // access the xaml code to access the xaml code from here (fs code)
  // (we ignore the result, the page loaded, we nned only the side effect ( :( )
  // let _ = base.LoadFromXaml(typeof<UndoRedoPage>) the same of the |> igonre 
  do base.LoadFromXaml(typeof<UndoRedoPage>) |> ignore

  let helloLabel = base.FindByName<Label>("helloLabel")
  let redoList = base.FindByName<ListView>("redoLV")
  let undoList = base.FindByName<ListView>("undoLV")

  let undoL = new ObservableCollection<ColorInfo>()
  let redoL = new ObservableCollection<ColorInfo>()
  do 
    // init items
    helloLabel.BackgroundColor <- Color.Red
    redoList.ItemsSource <- redoL
    undoList.ItemsSource <- undoL
  
  member __.OnButtonRedClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Red
    undoL.Insert(0, { Name="Red"; Color=Color.Red })
  
  member __.OnButtonFuchsiaClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Fuchsia
    undoL.Insert(0, { Name="Fuchsia"; Color=Color.Fuchsia })

  member __.OnButtonGreenClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Green
    undoL.Insert(0, { Name="Green"; Color=Color.Green })

  member __.OnButtonYellowClicked (sender:Object) (args:EventArgs) =
    helloLabel.BackgroundColor <- Color.Yellow
    undoL.Insert(0, { Name="Yellow"; Color=Color.Yellow })
  

type App() =
  inherit Application(MainPage = UndoRedoPage())   // hooking the app to our main page

 