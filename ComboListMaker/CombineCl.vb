Imports System.IO

Public Class CombineCl

  public Event RaiseFinishedList(ByVal sender As Object, byval comboList As List(Of String))

    Function LoadFile (ByVal fileLocation As String) As List(Of string)
        Dim listString  As List(Of String) = File.ReadAllLines(fileLocation).ToList()
       Return listString
    End Function

    
    public sub CombineList(byval usernames As list(of String), byval passwords As List(Of String))
        Dim combinesList As new List(Of String)
        For Each user As string In usernames
            For Each pass As string In passwords
                combinesList.Add(String.Format("{0}:{1}", user, pass))
            Next 
        Next
       RaiseEvent RaiseFinishedList(me, combinesList)

    End sub


End Class
