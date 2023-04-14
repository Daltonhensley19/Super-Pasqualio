# Super-Pasqualio
Group project for CS-312 (Game Prototype Design and Implementation)

<!-- TABLE OF CONTENTS -->
<details open="open">
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
    <li><a href="#testing">Testing</a></li>  
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>




## About The Project

![Project](https://www.oldcomputerbooks.com/pictures/R519.jpg?v=1590693199)
Image Source: https://www.oldcomputerbooks.com/pictures/R519.jpg?v=1590693199


This project is centered around emulating the Z80 Processor such that we can load and execute programs which are written using the Z80 instruction set. 

This project is capable of several forms of data manipulation and is created to be a digital recreation of the real life Z80 Processor 
architecture. There are several nonesssential operations which were not deemed necessary for the scope of this project. However, this project still aims to 
not only create an efficient and authentic emulation of the Z80, but also to demonstrate the data transformations it was capable of. We use a GUI debugger to visualize this output. This project currently supports most math functions from the Z80, as well as several other neccesary functions such as: loading, jumps, calls, 
returns, and more.


### Built With

* [CMake](https://cmake.org/download/)
* [C++/Visual Studio](https://support.microsoft.com/en-us/topic/the-latest-supported-visual-c-downloads-2647da03-1eea-4433-9aff-95f26a218cc0)
* [GCC](https://gcc.gnu.org/install/download.html) (if using Linux)




## Getting Started

This is an example of how you may give instructions on setting up the project locally.
To get a local copy up and running, follow these simple example steps.

### Prerequisites if using an Arch Based Linux Distro

You will need to install CMake, GCC, GLFW, and OpenGL.
* CMake
  ```sh
  sudo pacman -S cmake
  ```
* GCC
  ```sh
  sudo pacman -S gcc
  ```

### Prerequisites if using an Windows

You will need to install CMake, GCC, GLFW, QT, and OpenGL.
* [CMake](https://cmake.org/download/)
* [QT](https://www.qt.io/download-qt-installer)
* [Visual Studio](https://support.microsoft.com/en-us/topic/the-latest-supported-visual-c-downloads-2647da03-1eea-4433-9aff-95f26a218cc0)

Unfortunately there is some finickyness that comes with attempting to run this project on windows, mostly due to needing to download and install all of the necessary programs. Some users may experience problems attempting to compile this project on windows.


### Installation Using the Command Line (Assuming Linux or MacOS) 
1. Clone the repo
   ```sh
   git clone https://github.com/Daltonhensley19/z80_emu_group
   ```
2. Make a build directory
   ```sh
   cd z80_emu_group && mkdir build 
   ```
3. Generate Makefiles using CMake
   ```sh
   cd build && cmake ..
   ```
3. Build project 
   ```sh
   make
   ```

## Usage

Upon loading a rom and processing through instructions, the GUI will notify you if the load was 
successful. If the load was, you are free to go through the instructions one-by-one and observe the data manipulation via the GUI.
Upon encountering an error, the GUI should display an exception and help to describe the problem encountered.



## Testing

This project contains several hand written Z80 test programs. They are included in the complete source code for this project.
To navigate to this collection of files, first go to the SRC folder, then within it, select the roms file.
Within this folder, there are several folders which contain collections of test roms categorized by the instruction sets they test. 
You may also create and use your own roms using hexadecimal assuming they follow documented instructions. This project has full test coverage using DocTest, and should
accurately process and display data using these roms.

## License

Distributed under the MIT License. See `LICENSE` for more information.




## Contact 

Dalton Hensley -  dzhensley@moreheadstate.edu

Jared Howard - jnhoward2@moreheadstate.edu

Daniel Richards - dlrichards@moreheadstate.edu

Ethan Sexton - ecsexton@moreheadstate.edu

