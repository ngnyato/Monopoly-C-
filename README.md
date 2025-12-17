
<a id="readme-top"></a>
<!--



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/ngnyato/Monopoly-C-/tree/main">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Monopólio Sagres Edition</h3>

  <p align="center">
    A Portuguese Monopoly Variant in C# CLi
    <br />
    <a href="https://github.com/ngnyato/Monopoly-C-/tree/main"><strong>Explore the repository »</strong></a>
    <br />  
    <br />
    <a href="https://github.com/ngnyato/Monopoly-C-/issues/new">Report Bug</a>
    &middot;
    <a href="https://github.com/ngnyato/Monopoly-C-/issues/new">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

 <a href="https://github.com/ngnyato/Monopoly-C-/tree/main">
    <img src="images/logo2.png" alt="Logo" width="100" height="100">
  </a>

Monopoly-C is a console-based re-creation of Monopoly developed in C# as part of a school assignment for the Fundamentals of Programming course.
The goal of the project is to apply essential programming concepts—such as object-oriented design, collections, control flow, and modular code—while building a functional game system inspired by Monopoly and themed around Portugal.

The game uses a 7×7 Portuguese-themed board, stored as a matrix, where each tile has a unique name (e.g., Start, Chance, Green1, WaterWorks, Train, FreePark).
Players are created, validated, and added to a game session. Each turn is processed with simple commands, and movement across the board is handled using random values, wrap-around logic, and coordinate updates. The console outputs the player’s movement, new position, and the tile they land on for clear debugging and gameplay visibility.

This project demonstrates the use of classes (Player, GameController, BoardManager), dictionaries and lists for player management, and structured command parsing for interaction.
The architecture was designed to be easy to expand with new features such as property ownership, money transactions, taxes, Chance/Community cards, or a visual board display.

Developed as a school assignment, this project showcases both programming fundamentals and creativity, turning theoretical concepts into a working game logic system while keeping the code organized, readable, and extendable.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

This section lists the main technologies used in the development of this project:


<p align="center">

<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />

<img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />

<img src= "https://img.shields.io/badge/VS_Code-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white"/>

<img src="https://img.shields.io/badge/Linux-FCC624?style=for-the-badge&logo=linux&logoColor=black">


<img src="https://img.shields.io/badge/GitHub-121013?style=for-the-badge&logo=github&logoColor=white" />

<img src="https://img.shields.io/badge/School_Project-0A66C2?style=for-the-badge&logo=bookstack&logoColor=white" />

<img src="https://img.shields.io/badge/Console_Application-000000?style=for-the-badge&logo=windows-terminal&logoColor=white" />
 
</p>



<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is a Guide of how you are supposed to use/run this repository

### Prerequisites

To run this project you'll need dotnet 10.0, acess this link to download the package and install it.
* dotnet 
  ```sh
    https://dotnet.microsoft.com/en-us/download/dotnet/10.0
  ```

### Installation

Follow the steps below to install, build, and run the project according to the required folder structure.



1. **Clone the repository**
   ```sh
     git clone https://github.com/ngnyato/Monopoly-C-.git
   ```
2. **Navigate to the project folder**

    According to the assignment structure, the Program.cs file is located in:
     ```sh
       src/Project
   ```
   So enter that directory:
   ```sh
     cd .../Monopoly-C-/src/Project
   ```
3. **Build the project**

   Run the following command inside the Project folder:
   ```sh
   dotnet build 
   ```
   4.**Run the program**

   Execute the console application:
   ```js
   dotnet run  OR dotnet run /.csproj
   ```
   **5.(Optional) If you fork or copy this project, update the Git remote URL:**
   ```sh
   git remote set-url origin github_username/repo_name
   git remote -v # confirm the changes
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTRIBUTING -->
## Contributing

Contributions are welcome! Although this project was created as a school assignment, suggestions, improvements, and bug reports are always appreciated.

### How to contribute

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/YourFeatureName`)
3. Commit your Changes (`git commit -m 'Describe your feature'`)
4. Push to the Branch (`git push origin feature/YourFeatureName...again`)
5. Open a Pull Request and explain your changes

### Top contributors:

<a href="https://github.com/ngnyato/Monopoly-C-/graphs/contributors"> <img src="https://contrib.rocks/image?repo=ngnyato/Monopoly-C-" alt="Contributors" /> </a> <p align="right">(<a href="#readme-top">back to top</a>)</p> 

## What I Learned

This project allowed me to apply the programming concepts taught in the Fundamentals of Programming course.  
Throughout its development, I strengthened my understanding of:

- **Object-Oriented Programming (OOP):** creating and organizing classes such as `GameController`, `Player`, and `BoardManager`.  
- **Data structures:** using dictionaries, lists, and a 2D array to manage players and the board.  
- **Program flow and input handling:** interpreting user commands and controlling the game state.  
- **Game logic:** implementing a turn system, movement rules, and board interaction.  
- **Debugging and clean code:** identifying logic errors and improving code readability.  
- **Git usage:** managing the project through commits, branches, and GitHub workflow.

Overall, this project helped consolidate my programming fundamentals and improved my ability to structure and implement a functional C# application.

<!-- LICENSE -->
## License

Distributed under the MIT License.<a href="https://github.com/ngnyato/Monopoly-C-/blob/main/LICENSE"><strong>`LICENSE.txt`</strong></a> See for more information.

<a> 
<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Afonso Torres - [@torresxyz_](https://www.instagram.com/torresxyz_/) - afonsotorres953@gmail.com

Project Link: [https://github.com/ngnyato/Monopoly-C-](https://github.com/your_username/repo_name)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

This project was developed as part of the *Fundamentals of Programming* course in my Computer Science degree.  
I would like to express my appreciation to the instructors and academic staff who guided the learning process and provided the foundational knowledge required to complete this assignment.

Special thanks to:

- **Professor(s) of Fundamentals of Programming** — for teaching the core programming concets used throughout this project

   <a href="https://www.linkedin.com/in/amgsabino/?originalSubdomain=pt">Professor André Sabino</a> && <a href="https://www.linkedin.com/in/nathanpc/?originalSubdomain=pt"> Professor Nathan Campos </a>
- **IADE / Universidade Europeia Faculty** — for providing the academic structure and curriculum that supported the development of this work  


Additional resources that supported the technical development:

- [.NET Documentation](https://learn.microsoft.com/dotnet/)  
- [C# Language Reference](https://learn.microsoft.com/dotnet/csharp/)  
- [GitHub Documentation](https://docs.github.com)  
- [Shields.io](https://shields.io) — for badge generation  
- [contrib.rocks](https://contrib.rocks) — for contributor visuals  
- [Stack Overflow](https://stackoverflow.com) — general troubleshooting  


<p align="right">(<a href="#readme-top">back to top</a>)</p>
