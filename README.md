# GCM - Git Config Manager

## Overview

**GCM** (Git Config Manager) is a lightweight command-line utility designed to simplify the process of managing global Git user configurations. This tool allows users to easily switch between different Git user profiles, add or remove user profiles, and view the current global Git configuration—all from a single command-line interface.

## Features

* **Switch User Profiles:** Quickly switch between different Git user profiles using a simple command.
* **Add and Remove Profiles:** Easily add new user profiles or remove existing ones from the configuration list.
* **View Current Profile:** Check the currently active Git user profile with a single command.
* **List All Profiles:** Display all available Git user profiles stored in the configuration file.

## Installation

1. Download the `GCM.exe` file from the Releases page.
2. Place the `GCM.exe` file in a directory that's included in your system's PATH, or navigate to the directory containing the file in your terminal.
3. Prepare Configuration File:
* Create a `users.txt` file in the same directory as `GCM.exe`.
* Add user profiles in the following format:
```txt
id:name:email
```
* Example `users.txt`:
```txt
1:Brian Warner:marlyn_manson@metal.com
2:John Lowery:john5@guitar.com
```

## Usage

### Switch User Profile

To switch the global Git user configuration to a specific profile:
```bash
./GCM sign 1
```

### Add a New User Profile

To add a new user profile to the list:
```bash
./GCM add 3 "Evan Rachel Wood" "EwanWood@example.com"
```

### Remove a User Profile

To remove an existing user profile by its ID:
```bash
./GCM remove 2
```

### View Current Profile

To display the current global Git user configuration:
```bash
./GCM current
```

### List All User Profiles

To list all user profiles stored in the configuration file:
```bash
./GM all
```

