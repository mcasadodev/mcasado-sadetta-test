# A few comments

The focus is heavily made on the architecture of the project with a modular, scalable code base. The strongest point of it is the usage of an event system based on ScriptableObjects, rather than the singleton pattern, which is used only once, for the modal window.

This approach is extensively covered in the Unite talks by Richard Fine and Ryan Hipple, and this project is the result of all the work and research for over the years that I’ve made to get to this formula, where I take advantage of the dual nature of ScriptableObjects (both data and logic containers).
These are the links to the talks:
<br>
https://www.youtube.com/watch?v=6vmRwLYWNRo&t=74s&ab_channel=Unity
<br>
https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=3264s&ab_channel=Unity

A system of additive scenes is also used, where the code is all decoupled between scenes and separated by its functionality.
Those are the main points of this extensible architecture which I have setup in one day of gathering systems and implementing them in a cohesive project, with in this case no external assets at all.

<i>Note: 
<br> 
I am aware that a binary save system is much more stronger than a json save system, but for debugging purposes I went for json at first and I just didn`t have time to switch to a binary implementation as I rather prefered to focus on the quality of the code structure.</i>
