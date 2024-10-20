# SchneidOS Album Viewer

![image](https://github.com/user-attachments/assets/047344c4-1da3-4802-a81b-6c6271ad843f)


This repository contains Justin Schneider's submission to Griple for employment evaluation and consideration. The project README (that's this file, right here) will serve as both documentation of my thought process while completing the assignment, as well as a minor demonstration of my careless disregard for brevity in writing that -- hopefully -- conveys the personality and spirit I bring to any team I'm on.

> Please note: Though my tone, much like Griple's, may be casual and irreverent, I want to make clear my sincere gratitude for consideration for the position and my excitement at the possibility of working with developers of this team's caliber and pedigree. So yeah, like... thanks and woohoo!

## Project approach

Having received the instructions only minutes before my children returned home from school for the weekend, I tried to stay in Family mode and did an adequate job until they became otherwise occupied. I then read the directions and provided documentation and couldn't help but start working on my implementation in my head, which felt like cheating but also maybe a hidden loophole one identifies with the wisdom age affords.

I decided on the following approach while my children watched the 1994 classic film _The Mask_ starring Jim Carrey:

- A simple service for interacting with the JSONPlaceholder API
- A factory for creating the AlbumEntry instances
- A manager for tracking instantiated AlbumEntries
- A UI script for handling buttons and image rendering.
- During development, an additional manager was found to be needed to assist with placement of the objects

I also figured I'd implement the service, factory, and managers as ScriptableObjects because [Ryan Hipple said I can](https://www.youtube.com/watch?app=desktop&v=raQ3iHhE_Kk), and I've just been waiting for a chance to prove him right for a while now. While the implementation here is crude, it should at least avoid singletons and stupidly-coupled systems.

After identifying a few requirements, re-reading the instructions, and taking some notes (oh god, if I'm writing things down that's definitely starting to feel like I'm working on it) my brain began allowing external stimuli to be processed again. I _did_ also spend a bit of time before bed writing the document that would become this README, but that was totally creative work done for catharsis, and my moral relativism had ZERO issue not counting that time, so don't even sweat it.

> Planning time: ~15 min<br>
> Creative writing time: Irrelevant

## Project Requirements

1. API Integration

   - Use the JSONPlaceholder API (https://jsonplaceholder.typicode.com/) for fetching fake-ass photo data.

2. 3D Environment

   - Implement the solution in a 3D Unity environment because we're not planning on wearing ties here.

3. User Interface

   - Create a user-friendly interface for instantiating, selecting, and deleting AlbumEntry instances.

4. Error Handling

   - Implement proper error handling for API requests and data processing.

5. Performance
   - Ensure the application performs well in play mode, even with multiple AlbumEntry instances.

## Development

With planning done ahead of time, I started work off running my plan by Claude while the project was spinning up. Claude praised the idea and repeated back many of my ideas in different words, and I wondered yet again if AI was truly going to change the world in the way we're made to believe...

I wrote the first implementation of scripts and had a roughly functioning version of the app in ~40 minutes. I'll admit then that I got too excited... I started enhancing the placement functionality, refactored the UI script that had gotten too large and multi-responsibility, and added a few visual enhancements for fun. By the time I'd finished, a bit over 2 hours had passed.

> Development time: 2 hours-ish

## Conclusion

I probably could have completed the task more quickly, but doing things quickly isn't the skill I'm most trying to show off here, so I spent the extra time to show a bit more of what is.

I love having guidance on requirements but free reign to explore within the space, and this assignment captured that passion for me quite well. I'm looking forward to discussing it further!
