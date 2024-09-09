# GCM - Git Config Manager

## Overview

**GM** (Git Config Manager) is a lightweight command-line utility designed to simplify the process of managing global Git user configurations. This tool allows users to easily switch between different Git user profiles, add or remove user profiles, and view the current global Git configuration—all from a single command-line interface.

## Features

* **Switch User Profiles:** Quickly switch between different Git user profiles using a simple command.
* **Add and Remove Profiles:** Easily add new user profiles or remove existing ones from the configuration list.
* **View Current Profile:** Check the currently active Git user profile with a single command.
* **List All Profiles:** Display all available Git user profiles stored in the configuration file.

## Installation

1. Download the `GM.exe` file from the [Releases](https://github.com/incatswetrust/GCM/releases) page.
2. Place the `GM.exe` file in a directory that's included in your system's PATH, or navigate to the directory containing the file in your terminal.

## Usage

### Switch User Profile

To switch the global Git user configuration to a specific profile:
```bash
./GM sign 1
```

### Add a New User Profile

To add a new user profile to the list:
```bash
./GM add Oleksii oleksii@incatswetrust.dev
```

### Remove a User Profile

To remove an existing user profile by its ID:
```bash
./GM remove 2
```

### View Current Profile

To display the current global Git user configuration:
```bash
./GM current
```

### List All User Profiles

To list all user profiles stored in the configuration file:
```bash
./GM all
```

