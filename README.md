# :video_game: FitFactory-7

Overview:
FitFactory-7 is a virtual reality fitness game that aims to make exercising fun and interactive for players. The game features a combination of cardio, boxing, dance and HIIT (High-Intensity Interval Training) all while immersed in a virtual world. FitFactory-7 is designed for players of all fitness levels, providing a gamified approach to fitness that encourages players to exercise regularly.

Game Mechanics:
The core gameplay loop of FitFactory-7 revolves around performing exercises to the beat of the music. Players must perform a variety of exercises in 7 minutes with the music, such as jabs, hooks, uppercuts, dance moves, and cardio exercises. The game includes a scoring system that rewards the player for performing exercises accurately and on time. 

Gameplay Flow:
The game starts by presenting the player within the factory where the workout will take place. Once the player starts the workout, they can choose a difficulty level that suits their fitness level (easy, medium and hard). In the virtual environment, the player is presented with a series of exercises that they must perform in time with the music. 
After completing a workout, players receive a summary of their performance including their score. 

Visuals:
FitFactory-7 showcases a minimalistic visual with a plain white color that will immerse players in the workout. The virtual environments intents to reduce the distractions to its most basic an essential component, allowing your body and mind to be fully focus on your body moments.

Audio:
The game will be only featuring an upbeat music that corresponds to the workout. The music is carefully selected to match the tempo and rhythm of the exercises, providing the player with an immersive and engaging experience. In this case, we will use the song Unity by “The Fat Rat.” To calculate the tempo or beats per minute (BPM):

-Identify a repeating rhythm, such as the bass drum or a snare hit. 
-Count the number of beats that occur in 15 seconds using a stopwatch or timer.
-Multiply the number of beats counted in 15 seconds by 4. This will give you the number of beats in one minute.
-Round the result to the nearest whole number. This is the song's BPM.

In this specific scenario, the song is 105 beats/minute so if you want to calculate how many seconds between beats you must divide the 60/105 and you will obtain the seconds between beats.  
 The game also features sound effects that provide players with feedback on their performance, such as the sound of a punch landing or an avoiding being hit by an intruder.

User Interface:
FitFactory-7 user interface is designed to be intuitive and easy to use. Players can select their difficulty level using a menu system that is easy to navigate. During the workout, the game provides on-screen instructions and prompts to guide players through the exercises. The game also includes a summary screen during the workouts where the feedback of their performance is shown:
-Boxes Missed
-Boxes Hit
-Total number of boxes
-Timer

Important Game Mechanics:
Interactors verses Interactable
•	Hand Physics
 -C# Scripting
   -Hand presence
     -Activate Grab Ray
     -Animate Hand on Input
 	   -Grab Interactable Two Attach
   -Full body Physic
     -Head
 -Animation

Diegetic UI and Countdown Visual
  -C# Scripting
     -Dead Wall
     -Boxes Missed
     -Total Boxes Missed Script
     -Boxes Hit Script
     -Timer Script
     -Countdown Controller 
     -Game Manager 
     -Cube Spawner
     -Punch 
     -Generate Hatic Feedback
     -Cube movement 
     
Enemy
 -C# Scripting
     -Enemy
         -On Collision Enter Death
         -On Trigger Enter Death
         -AI (Distance from user player)
         -Death behavior
         -Attack behavior
      -Pistol
         -Fire Bullet on Activate
         -Rotate
         -Velocity Estimator

Powe-Ups
 -C# Scripting
     -Freeze time
     -Teleport back to initial position
     -Switch from three to six degree of freedom

Technical Requirements:
FitFactory-7 is designed for use with virtual reality (VR) headsets, such as the Oculus Quest. The game requires a VR headset and motion controllers to play. The game is developed using the Unity game engine and Oculus SDK. 

