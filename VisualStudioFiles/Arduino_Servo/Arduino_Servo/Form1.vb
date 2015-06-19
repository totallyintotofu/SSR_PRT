'created by Rui Santos, http://randomnerdtutorials.wordpress.com, 2013
'modified by Laura Boccanfuso, Lisa Chen and Colette Torres 6/2015
'Control a servo motor with Visual Basic 

Imports System.Speech.Synthesis
Imports System.IO
Imports System.IO.Ports
Imports System.Threading

Public Class Form1

    Shared _continue As Boolean
    Shared _serialPort As SerialPort
    WithEvents speaker As New SpeechSynthesizer()
    Public Event VisemeReached As EventHandler(Of VisemeReachedEventArgs)
    Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)

    'Dim promptBuilder As PromptBuilder
    'Dim returnValue As Prompt

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialPort1.Close()
        SerialPort1.PortName = "COM6" 'define your port
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
        Thread.Sleep(1000)
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True


    End Sub

    Private Sub neutral_Click(sender As System.Object, e As System.EventArgs) Handles neutral.Click, Timer3.Tick
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
    End Sub

    Private Sub smile_Click_1(sender As Object, e As EventArgs) Handles smile.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("0")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub sad_Click(sender As Object, e As EventArgs) Handles frown.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("1")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub blink_Click(sender As Object, e As EventArgs) Handles blink.Click, Timer1.Tick
        SerialPort1.Open()
        SerialPort1.Write("3")
        SerialPort1.Close()
    End Sub

    Private Sub SpeakFritz_Click(sender As Object, e As EventArgs) Handles SpeakFritz.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Hello! I'm going to try to say something and move my mouth at the same time!! How am I doing??  After a few sentences, does my mouth keep up with my words??"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)

    End Sub

    Private Sub speaker_VisemeReached(sender As Object, e2 As System.Speech.Synthesis.VisemeReachedEventArgs) Handles speaker.VisemeReached
        Console.WriteLine("Viseme " & e2.Viseme & " was " & e2.Duration.TotalMilliseconds.ToString & " ms. long" & vbNewLine)

        '0:      silence()
        '1:      ae, ax, ah
        '2:      aa()
        '3:      ao()
        '4:      ey, eh, uh
        '5:      er()
        '6:      y, iy, ih, ix
        '7:      w, uw4
        '8:      ow()
        '9:      aw()
        '10:     oy()
        '11:     ay()
        '12:     h()
        '13:     r()
        '14:     l()
        '15:     s, z
        '16:     sh, ch, jh, zh
        '17:     th, dh
        '18:     f, v
        '19:     d, t, n
        '20:     k, g, ng
        '21:     p, b, m

        Try
            If (e2.Viseme = 1 Or e2.Viseme = 2 Or e2.Viseme = 9 Or e2.Viseme = 8) Then
                SerialPort1.Open()
                SerialPort1.Write("4")
                SerialPort1.Close()
            ElseIf (e2.Viseme = 3 Or e2.Viseme = 6 Or e2.Viseme = 10) Then
                SerialPort1.Open()
                SerialPort1.Write("5")
                SerialPort1.Close()
            ElseIf (e2.Viseme = 4 Or e2.Viseme = 5 Or e2.Viseme = 7 Or e2.Viseme = 20) Then
                SerialPort1.Open()
                SerialPort1.Write("6")
                SerialPort1.Close()
            Else
                SerialPort1.Open()
                SerialPort1.Write("7")
                SerialPort1.Close()
            End If
        Catch e As Exception
            Console.WriteLine("exception caught")
        End Try



    End Sub

    Private Sub EyeRight_Click(sender As Object, e As EventArgs) Handles EyeRight.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("8")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub EyeLeft_Click(sender As Object, e As EventArgs) Handles EyeLeft.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("9")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        speaker.SpeakAsyncCancelAll()
        SerialPort1.Open()
        SerialPort1.Write("10")
        SerialPort1.Close()
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
    End Sub

    Private Sub HeadLeft_Click(sender As Object, e As EventArgs) Handles HeadLeft.Click, Timer2.Tick
        SerialPort1.Open()
        SerialPort1.Write("A")
        SerialPort1.Close()
    End Sub

    Private Sub HeadRight_Click(sender As Object, e As EventArgs) Handles HeadRight.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("B")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub
    Private Sub Oh_Click(sender As Object, e As EventArgs) Handles Oh.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Oh"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Okay_Click(sender As Object, e As EventArgs) Handles Okay.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Okay..."
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Hmmm_Click(sender As Object, e As EventArgs) Handles Hmmm.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Wow.  Ok."
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Mhmm_Click(sender As Object, e As EventArgs) Handles Mhmm.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Interesting....."
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Cool_Click(sender As Object, e As EventArgs) Handles Cool.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Cool"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub
    Private Sub Nice_Click(sender As Object, e As EventArgs) Handles Nice.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Nice"
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub
    Private Sub Yeah_Click(sender As Object, e As EventArgs) Handles Yeah.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Yeah"
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub
    Private Sub Um_Click(sender As Object, e As EventArgs) Handles Um.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Uhhhhhhuh...."
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub
    Private Sub Hello_Click(sender As Object, e As EventArgs) Handles Hello.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Hello"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub
    Private Sub Hi_Click(sender As Object, e As EventArgs) Handles Hi.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Hi, my name is Fritz"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    'Private Sub Yawn_Click(sender As Object, e As EventArgs) Handles Yawn.Click
    '    Timer1.Enabled = False
    '    SerialPort1.Open()
    '    SerialPort1.Write("O")
    '    SerialPort1.Close()
    '    My.Computer.Audio.Play(My.Resources.Elves, AudioPlayMode.WaitToComplete)

    'End Sub

    'Private Sub Burp_Click(sender As Object, e As EventArgs) Handles Burp.Click
    '    Timer1.Enabled = False
    '    SerialPort1.Open()
    '    SerialPort1.Write("P")
    '    SerialPort1.Close()
    '    My.Computer.Audio.Play(My.Resources.Elves, AudioPlayMode.WaitToComplete)
    'End Sub

    'Private Sub NotAgain_Click(sender As Object, e As EventArgs) Handles NotAgain.Click
    '    Timer1.Enabled = False
    '    Timer2.Enabled = False
    '    Timer3.Enabled = False

    '    Dim string2say As String
    '    Dim string2say2 As String
    '    Dim string2say3 As String
    '    Dim string2say4 As String
    '    Dim string2say5 As String

    '    string2say = "Hello. I’m good."
    '    string2say2 = "I went to my friend’s birthday party."
    '    string2say3 = "Yeah."
    '    string2say4 = "I went to a pool party and I swam and I ate pizza and cake."
    '    string2say5 = "Yeah. I played on the playground. The slide was very big."
    '    speaker.Rate = 1
    '    speaker.Volume = 100
    '    speaker.SelectVoice("IVONA 2 Ivy OEM")
    '    System.Threading.Thread.Sleep(2000)
    '    SerialPort1.Open()
    '    SerialPort1.Write("0")
    '    SerialPort1.Close()
    '    speaker.Speak(string2say)
    '    System.Threading.Thread.Sleep(1700)
    '    speaker.Speak(string2say2)
    '    SerialPort1.Open()
    '    SerialPort1.Write("2")
    '    SerialPort1.Close()
    '    System.Threading.Thread.Sleep(4000)
    '    SerialPort1.Open()
    '    SerialPort1.Write("3")
    '    SerialPort1.Close()
    '    speaker.Speak(string2say3)
    '    SerialPort1.Open()
    '    SerialPort1.Write("A")
    '    SerialPort1.Close()
    '    SerialPort1.Open()
    '    SerialPort1.Write("9")
    '    SerialPort1.Close()
    '    speaker.SpeakAsync(string2say4)
    '    SerialPort1.Open()
    '    SerialPort1.Write("T")
    '    SerialPort1.Close()
    '    SerialPort1.Open()
    '    SerialPort1.Write("R")
    '    SerialPort1.Close()
    '    speaker.Speak(string2say5)
    '    SerialPort1.Open()
    '    SerialPort1.Write("2")
    '    SerialPort1.Close()
    'End Sub

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        Dim message As String
        message = TextBox1.Text
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(message)
    End Sub

    Private Sub HeadUp_Click(sender As Object, e As EventArgs) Handles HeadUp.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("C")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub HeadDown_Click(sender As Object, e As EventArgs) Handles HeadDown.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("D")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Convo1_Click(sender As Object, e As EventArgs) Handles Convo1.Click
        Dim string2say As String
        string2say = "Hello. My name is Fritz. I am having a very good day."
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)

    End Sub

    Private Sub Wink_Click(sender As Object, e As EventArgs) Handles Wink.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("E")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Confused_Click(sender As Object, e As EventArgs) Handles Confused.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("F")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Surprised_Click(sender As Object, e As EventArgs) Handles Surprised.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("G")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Angry_Click(sender As Object, e As EventArgs) Handles Angry.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("H")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub
    Private Sub speaker_SpeakCompleted(sender As Object, e2 As System.Speech.Synthesis.SpeakCompletedEventArgs) Handles speaker.SpeakCompleted
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub CrossEyed_Click(sender As Object, e As EventArgs) Handles CrossEyed.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("I")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Awkward_Click(sender As Object, e As EventArgs) Handles Awkward.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("J")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub FunnyFace1_Click(sender As Object, e As EventArgs) Handles FunnyFace1.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("K")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Afraid_Click(sender As Object, e As EventArgs) Handles Afraid.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("L")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Sleepy_Click(sender As Object, e As EventArgs) Handles Sleepy.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("M")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Yelling_Click(sender As Object, e As EventArgs) Handles Yelling.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("N")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub
    Private Sub Animated_Click(sender As Object, e As EventArgs) Handles Animated.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Funny2_Click(sender As Object, e As EventArgs) Handles Funny2.Click
        SerialPort1.Open()
        SerialPort1.Write("Q")
        SerialPort1.Close()
    End Sub


    Private Sub Script1_Click(sender As Object, e As EventArgs) Handles Script1.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        Dim string2say2 As String
        Dim string2say3 As String
        Dim string2say4 As String
        Dim string2say5 As String
        Dim string2say6 As String
        Dim string2say7 As String
        Dim string2say8 As String
        Dim string2say9 As String
        Dim string2say10 As String
        string2say = "Hello. I’m good."
        string2say2 = "I went to my friend’s birthday party."
        string2say3 = "Yeah."
        string2say4 = "I went to a pool party and I swam and I ate pizza and cake."
        string2say5 = "Yeah. I played on the playground. The slide was very big."
        string2say6 = "Chocolate."
        string2say7 = "Okay."
        string2say8 = "Oh yeah, and I also played with my friend Jimmy. We went off the diving board. I did a cannon ball."
        string2say9 = "Okay."
        string2say10 = "Cool"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        System.Threading.Thread.Sleep(2000)
        SerialPort1.Open()
        SerialPort1.Write("0")
        SerialPort1.Close()
        speaker.Speak(string2say)
        System.Threading.Thread.Sleep(1700)
        speaker.Speak(string2say2)
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(4000)
        SerialPort1.Open()
        SerialPort1.Write("3")
        SerialPort1.Close()
        speaker.Speak(string2say3)
        System.Threading.Thread.Sleep(3000)
        SerialPort1.Open()
        SerialPort1.Write("A")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("9")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(4000)
        speaker.Speak(string2say4)
        System.Threading.Thread.Sleep(3000)
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say5)
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("A")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("9")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(3500)
        SerialPort1.Open()
        SerialPort1.Write("3")
        SerialPort1.Close()
        speaker.Speak(string2say6)
        System.Threading.Thread.Sleep(3000)
        SerialPort1.Open()
        SerialPort1.Write("S")
        SerialPort1.Close()
        speaker.Speak(string2say7)
        System.Threading.Thread.Sleep(900)
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say8)
        System.Threading.Thread.Sleep(4000)
        speaker.Speak(string2say9)
        System.Threading.Thread.Sleep(6500)
        SerialPort1.Open()
        SerialPort1.Write("3")
        SerialPort1.Close()
        speaker.Speak(string2say10)
        System.Threading.Thread.Sleep(1000)
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Script2_Click(sender As Object, e As EventArgs) Handles Script2.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        Dim string2say2 As String
        Dim string2say3 As String
        Dim string2say4 As String
        Dim string2say5 As String
        Dim string2say6 As String
        Dim string2say7 As String
        Dim string2say8 As String
        Dim string2say9 As String
        string2say = "I like to play Super Mario Bros."
        string2say2 = "I also like this cool Lego game."
        string2say3 = "Luigi."
        string2say4 = "I like him."
        string2say5 = "My favorite color is green."
        string2say6 = "Oh yeah, in the Lego Game my character is also green."
        string2say7 = "Yeah"
        string2say8 = "I like watching TV"
        string2say9 = "TV is funny.  Like this face!"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        System.Threading.Thread.Sleep(3000)
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say)
        System.Threading.Thread.Sleep(3000)
        speaker.Speak(string2say2)
        System.Threading.Thread.Sleep(3800)
        speaker.Speak(string2say3)
        System.Threading.Thread.Sleep(3000)
        speaker.Speak(string2say4)
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(2000)
        speaker.Speak(string2say5)
        System.Threading.Thread.Sleep(1200)
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say6)
        System.Threading.Thread.Sleep(7000)
        SerialPort1.Open()
        SerialPort1.Write("3")
        SerialPort1.Close()
        speaker.Speak(string2say7)
        System.Threading.Thread.Sleep(4000)
        SerialPort1.Open()
        SerialPort1.Write("C")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("8")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("B")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(1100)
        speaker.Speak(string2say8)
        System.Threading.Thread.Sleep(1500)
        SerialPort1.Open()
        SerialPort1.Write("S")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say9)
        System.Threading.Thread.Sleep(600)
        SerialPort1.Open()
        SerialPort1.Write("Q")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(1000)
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Script3_Click(sender As Object, e As EventArgs) Handles Script3.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        Dim string2say2 As String
        Dim string2say3 As String
        Dim string2say4 As String
        Dim string2say5 As String
        Dim string2say6 As String
        Dim string2say7 As String
        string2say = " School is fun sometimes."
        string2say2 = "I like recess. "
        string2say3 = "I hate math."
        string2say4 = "Idontknow."
        string2say5 = "Math is boring."
        string2say6 = "Do you like cookies?  I love cookies."
        string2say7 = "Does that mean we can have some right now?"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        System.Threading.Thread.Sleep(1500)
        SerialPort1.Open()
        SerialPort1.Write("9")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("A")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(800)
        speaker.Speak(string2say)
        System.Threading.Thread.Sleep(2000)
        SerialPort1.Open()
        SerialPort1.Write("S")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say2)
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(1800)
        speaker.Speak(string2say3)
        System.Threading.Thread.Sleep(2000)
        speaker.Rate = 8
        speaker.Speak(string2say4)
        speaker.Rate = 1
        SerialPort1.Open()
        SerialPort1.Write("9")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("A")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("3")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(2800)
        SerialPort1.Open()
        SerialPort1.Write("S")
        SerialPort1.Close()
        SerialPort1.Open()
        SerialPort1.Write("C")
        SerialPort1.Close()
        speaker.Speak(string2say5)
        System.Threading.Thread.Sleep(900)
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
        System.Threading.Thread.Sleep(2000)
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say6)
        System.Threading.Thread.Sleep(2000)
        speaker.Speak(string2say7)
        SerialPort1.Open()
        SerialPort1.Write("E")
        SerialPort1.Close()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub Staller1_Click(sender As Object, e As EventArgs) Handles Staller1.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "That's a good question!... Let me think..."
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Staller2_Click(sender As Object, e As EventArgs) Handles Staller2.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "I'm not sure...  I'll have to ask my mom."
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Staller3_Click(sender As Object, e As EventArgs) Handles Staller3.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Welllllll...."
        speaker.Rate = 0.5
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Staller4_Click(sender As Object, e As EventArgs) Handles Staller4.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim string2say As String
        string2say = "Sorry, can you say that again?"
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub
    Private Sub Interrupt1_Click(sender As Object, e As EventArgs) Handles Interrupt1.Click
        Dim string2say As String
        string2say = "Do you like cookies? I love cookies!"
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say)
    End Sub

    Private Sub Interrupt2_Click(sender As Object, e As EventArgs) Handles Interrupt2.Click
        Dim string2say As String
        string2say = "Oh yeah. This weekend was my friend Bob's birthday!"
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Speak(string2say)
    End Sub
    Private Sub LikeSubmit_Click(sender As Object, e As EventArgs) Handles LikeSubmit.Click
        Dim message As String
        message = LikeBox.Text
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync("I like " + message)
    End Sub

    Private Sub DontLikeSubmit_Click(sender As Object, e As EventArgs) Handles DontLikeSubmit.Click
        Dim message As String
        message = DontLikeBox.Text
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync("I don't like " + message)
    End Sub

    Private Sub FaveSubmit_Click(sender As Object, e As EventArgs) Handles FaveSubmit.Click
        Dim message1, message2 As String
        message1 = Fave1.Text
        message2 = Fave2.Text
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync("My favorite " + message1 + "is " + message2)
    End Sub

    Private Sub School1_Click(sender As Object, e As EventArgs) Handles School1.Click
        Dim string2say As String
        string2say = "I love recess.  Playing in the playground is always fun!"
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
    End Sub

    Private Sub School2_Click(sender As Object, e As EventArgs) Handles School2.Click
        Dim string2say As String
        string2say = "Reading is boring"
        SerialPort1.Open()
        SerialPort1.Write("R")
        SerialPort1.Close()
        speaker.Rate = 0.2
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.SpeakAsync(string2say)
        SerialPort1.Close()
    End Sub

    Private Sub School3_Click(sender As Object, e As EventArgs) Handles School3.Click
        Dim string2say As String
        string2say = "My teacher's pretty nice"
        speaker.SpeakAsync(string2say)
    End Sub
    Private Sub School4_Click(sender As Object, e As EventArgs) Handles School4.Click
        Dim string2say As String
        string2say = "School's not bad"
        speaker.SpeakAsync(string2say)
    End Sub

    Private Sub Pause_Click(sender As Object, e As EventArgs) Handles Pause.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        speaker.Pause()
    End Sub

    Private Sub ResumeButton_Click(sender As Object, e As EventArgs) Handles ResumeButton.Click
        speaker.Resume()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
    End Sub

    Private Sub LikeBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LikeBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            Dim message As String
            message = LikeBox.Text
            speaker.Rate = 0.2
            speaker.Volume = 100
            speaker.SelectVoice("IVONA 2 Ivy OEM")
            speaker.SpeakAsync("I like " + message)
        End If
    End Sub

    Private Sub DontLikeBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DontLikeBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            Dim message As String
            message = DontLikeBox.Text
            speaker.Rate = 0.2
            speaker.Volume = 100
            speaker.SelectVoice("IVONA 2 Ivy OEM")
            speaker.SpeakAsync("I don't like " + message)
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            Dim message As String
            message = TextBox1.Text
            speaker.Rate = 0.2
            speaker.Volume = 100
            speaker.SelectVoice("IVONA 2 Ivy OEM")
            speaker.SpeakAsync(message)
        End If
    End Sub

    Private Sub ICANDO_eyes_Click(sender As Object, e As EventArgs) Handles ICANDO_eyes.Click
        Dim string2say As String
        string2say = "Look what I can do with my eyes!!"
        speaker.Rate = 1
        speaker.Volume = 100
        speaker.SelectVoice("IVONA 2 Ivy OEM")
        speaker.Speak(string2say)
        SerialPort1.Open()
        SerialPort1.Write("S")
        SerialPort1.Close()

        'builder.AppendText("Get in the house.", PromptEmphasis.Moderate)
        'builder.AppendBreak()
        'builder.AppendText("Get in the house now.", PromptEmphasis.Strong)
        'speaker.SpeakAsync(builder)
    End Sub
End Class