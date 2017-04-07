namespace undoRedo

open Xamarin.Forms
open Xamarin.Forms.Xaml

type undoRedoPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<undoRedoPage>)
