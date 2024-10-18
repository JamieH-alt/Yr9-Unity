# 9CT1A Task #3 Part B.

## Identifying And Defining
### Identifying a need

#### Brainstorming
* Improving critical thinking skills in children | Detective Game
* Improving reaction times among kids | Whack-a-mole style game.
* Memory skills | Card Match Game
* Memory, critical thinking, logic, numeracy amongst children | Card Game Suite

#### Identify
**Need:** To improve children's memory, critical thinking skills, logic, and numeracy skills via an engaging game consisting of several small card games. \
**Problem Statement:** Children (6 -> 11, G) are often only able to focus on things they find fun and exciting, this proves to be a problem within classrooms, due to the ever decreasing attention spans within young children. This means that educational yet fun games are vital to their learning. A game that provides a suite of card games could easily prove to be a great assistance within the classroom. By having students play simple games such as Oicho-Kabu, Irish Rummy-O, Etc... \
**Skill Development:** I would develop any required skills for making this game by looking at things like Stackover-flow solutions.

#### Requirements Outline
**Inputs:** User inputs will be mouse clicks for selecting the amount of money, cards and actions, as the game will be mainly UI based, and we will need inputs from the save files to store player data. \
**Processing:**
The program will process the inputs and update the game score aswell as the cards, table, and other stats. \
**Outputs:** The game will often run the processed changed on the input, then play a sound for some virtual "tactiLe" feedback, and then display the updated screen. \
**Transmission:** The project will not require any transmission as all accounts are local. \
**Storage:** High scores on games need to be stored, usernames and passwords, to help schools have multiple students per computer.

#### Functional Requirements
**User Interaction:** Users will interact through the system via clicking cards or actions on the UI, essentially just selecting options, This can be to draw new cards / move to the next step of the card game. \
**Core Gameplay or Simulation Mechanics:** Randomisation for the card drawing, basic math, and algorithmic decisions by the computer on whats the best move. \
**Scoring and Feedback:** At the end of each match the game will show the player their score, if they won or lost etc... but the purpose of the game is to not give the players any real number feedback so the students can gain math skills. \
**Level Progression or Simulation Stages:** Levelling within my game woulde be quite simple, with points gained over time able to be spent on different card designs. \
**Saving and Loading Data:** The game will handle saving and loading data via saving the statistics into am ENCRYPTED JSON at any important moments, and then on the restart of the game they would load the stats from the same ENCRYPTED JSON file. The ENCRYPTED JSON file would be stored locally on the user's device.
#### Non-Functional Requirements Instructions
**Performance Requirements:** The game should load within 5-10 seconds and provide feedback to the user (sound), that their inputs have been registered instantly, actual processing is alright to take time as card games are turn based. \
**Usability Requirements:** The userinterface should require no onscreen prompts besides itself, though for each game a tutorial would be made as its expected for the user to be introduced to card games they haven't played before. \
**Compatability Requirements:** The game should run as a simple PC game, aswell as a browser game so schools don't have to download anything. It would also be prefered if they didn't require strong computers. \
**Scalability Requirements:** The game should have no issues scaling as each game will have its own script, essentially making it a library for games. So the only real scalability requirement would be a scrollable level select menu, or paged system, so its as simple as coding a new card game. \
**Security Requirements:** To prevent anyone cheating in scores, or using other peoples accounts, all usernames and passwords will be hashed in SHA256 then stored in the ENCRYPTED JSON which will be encrypted through a key hard coded into the game. The password will then be hashed in SHA256 then checked with the pre-existing hash to see if they are equal. \
**Reliability and Availability:** The system should be able to handle simple errors like crashing by reverting to the last save file.
### Defining
#### Consideration of Social and Ethical Issues
**Equity:**
Equity is defined as "fairness and justice", not to be confused with equality. Where-in equality believes everyone should have the same starting point, Equity believes we should all have the same finish point. Meaning those in-need are given more leeway and assistance than those who find themselves ahead. \
**Accessibility:**
Accessibility is often seen as the ability to access and benefit from a system. This is often seen in technology through assistive features such as colour blindness modes, text to speech, etc.
