# UA-5724-lessons

This repository contains the code and materials for the lessons in the UA-5724 course. Each lesson is organized in its own directory, with accompanying code examples, exercises, and resources.


# HW
- [Homework #1: Working with Git and Branching](hw/hw01/README.md)
- [Homework #2: Console Applications](hw/hw02/README.md)
- [Homework #3: Methods and Arrays](hw/hw03/README.md)
- [Homework #4: Operators and Loops](hw/hw04/README.md)
- [Homework #5: Classes and Objects](hw/hw05/README.md)
- [Homework #6: Interfaces and Collections](hw/hw06/README.md)
- [Homework #7: Abstract Classes and Polymorphism](hw/hw07/README.md)
- [Homework #8: Handling Exceptions and Working with Files and directories](hw/hw08/README.md)
- [Homework #9: Composition and Aggregation + Unit Testing](hw/hw09/README.md)
- [Homework #10: Advanced C# Topics](hw/hw10/README.md)

Below is a README section you can copy directly into your GitHub repository.


## 📤 How to Submit Your Homework

To submit your homework, please follow these steps carefully.

### 1. Update your local `main` branch

Before starting your homework, make sure your local `main` branch is up to date.

```bash
git checkout main
git pull origin main
```

### 2. Create a new branch

Create a new branch from the updated `main` branch.

>
> **Branch naming example:**
> ```text
> homework/hwNN-your-nickname
> ```
>
> Example:
>
> ```text
> homework/hw03-johndoe
> ```

```bash
git checkout -b homework/hwNN-your-nickname
```

### 3. Add your solution

Place your implementation in the following directory structure:

```text
hw/
└── hwNN/
    └── <Nickname>/
        └── ...
```

Example:

```text
hw/
└── hw03/
    └── JohnDoe/
        ├── solution.js
        ├── README.md
        └── assets/
```

### 4. Commit your changes

Stage all changes and create a meaningful commit.

```bash
git add .
git commit -m "Add homework HWNN by <Nickname>"
```

### 5. Push your branch

Upload your branch to the remote repository.

```bash
git push -u origin homework/hwNN-your-nickname
```

### 6. Create a Pull Request

Open a Pull Request from your branch to the **`main`** branch.

Please ensure that:

- ✅ Your branch is created from the latest `main`.
- ✅ Your homework is placed in the correct folder.
- ✅ The project builds successfully (if applicable).
- ✅ The Pull Request title clearly identifies your homework.

### ✔ Submission Checklist

- [ ] Updated the local `main` branch
- [ ] Created a new branch from `main`
- [ ] Added the solution to `hw/<hwNN>/<Nickname>/`
- [ ] Committed all changes
- [ ] Pushed the branch to GitHub
- [ ] Created a Pull Request targeting `main`

