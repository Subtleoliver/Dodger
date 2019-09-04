# Dodger
Game about dodging falling things originally made in 2016 with Unity.

I don't think I had looked at the code for this since then and it does have a lot of questionable decisions when it comes to code. 
Perhaps I will completely rewrite it someday using the latest Unity features but until then this is an example of my early code.

Noteable problems:
- 0 comments.
- The movement is "floaty"
- There isn't an animation causing the ship sprite to lean it is actually being rotated.
- The Asteroids that spawn just spawn randomly which can cause a lot of headaches. The work around for this was adding a gun.

The only changes made in this recompiled 2019 version:
- Decreased the amount of Asteroids that can spawn at once from 9(!!!) to 5 and upped the minimum to 3 (from 1).
- Decreased player movement speed and added a bit of dampening to make it feel slightly less glidey.
- Rebuilt lightning.
- Build in Unity 19.3.0a12

# How to play

Move left and right using A & D.
Shoot with LEFT MOUSE BUTTON.

At the top left you see how many bullets you have. Your goal is to dodge the asteroids for as long as possible.
