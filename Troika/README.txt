
This document contains a tentative list of bug fixes and game 
improvements as well as the inputs for Windows controls
(towards the bottom). Feel free to expand upon it and remember 
to comment out completed goals. 

Thanks!
  Phoenix

P.S. Troika means set of three it's also a type of Russian folk dance.
     Also I may move this README to a Google Doc.


// Implement laser disintegration for Big (aka Saxon? or Arthur?) and Sam
  Add a shock effect for Slink (in need of a name)

- Add a buzzing sound/disintegration sound for the laser

- Ensure Sam's cursor moves when space is pressed?

// Halt Sam's movement when he is in Big's arms
	// currently Sam moves slowly while held

- Fix the bug where Slink can drag big through a wall?
  Ask Phoenix for more details

- Add idle animations for characters
	+ Twiddle mustache for Big (and blink?)
	+ Take drag for Sam
	+ Blink for Slink ;)

// Destroy anything that falls off the play area
// and reset the level if it is a character

// Make big more pushable by Slink by adjusting Big's mass

// Don't delete top block when hiding the laser
- Add indication for the laser coming back on

// Remove Audio helper script and replace with something else

- Break the wall when Big throws the terminal

- Ensure the terminal always changes to the hackable state

- Add UI prompts for the tutorials and hints for players stuck

- Add 8 or more additonal levels

- Add additonal sound effects and change some of the pre-existing

- Polish Slink's movement  

Notes involving tutorial implementation:

- Big learns moving/pacing

- Slink learns movement and does a lap around his cell

- Sam taunts Big

- Big picks up the console and throws it through his cell into Sam's
  The camera tracks the console

- Sam learns movement while going towards the console and then stops
  Sam learns to hack

- Camera pans out and the floors drop
  Camera behaviour becomes normal

- Sam falls into a hole and has to jump out

- Big walks into the same hole

- Slink is a nice guy so he helps big out by using the middle click



Below are the inputs for Windows. Because I've been testing on my Mac,
the inputs for OSX should already be in place. However, just ask if you need them.

Windows Inputs:

"Left"
Positive Button: joystick button 2
Type: Key or Mouse Button
Axis: X axis
Joy Num: Get Motion from all Joysticks


"Right"
Positive Button: joystick button 1
Type: Key or Mouse Button
Axis: X axis
Joy Num: Get Motion from all Joysticks


"Grab"
Positive Button: joystick button 5
Type: Key or Mouse Button
Axis: X axis
Joy Num: Get Motion from all Joysticks


"Rotate Vert"
Type: Joystick Axis
Axis: 5th axis (Joysticks)
Joy Num: Joystick 1


"Rotate Horz"
Type: Joystick Axis
Axis: 4th axis (Joysticks)
Joy Num: Joystick 1


"Horizontal"
Type: Joystick Axis
Axis: X axis
Joy Num: Get Motion from all Joysticks


"Ignore"
Positive Button: joystick button 7
Type: Key or Mouse Button
Axis: X axis
Joy Num: Get Motion from all Joysticks