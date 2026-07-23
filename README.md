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
- [Homework #8: Handling Exceptions and Working with Files and Directories](hw/hw08/README.md)
- [Homework #9: Composition and Aggregation + Unit Testing](hw/hw09/README.md)
- [Homework #10: Advanced C# Topics](hw/hw10/README.md)

---

# 📤 How to Submit Your Homework

Follow these steps to submit your homework correctly.

## 1. Update your local `main` branch

Before starting your homework, make sure your local `main` branch is up to date.

```bash
git checkout main
git pull origin main
```

## 2. Create a new branch

Create a new branch from the updated `main` branch.

**Branch naming convention**

```text
homework/hwNN-your-nickname
```

Example:

```text
homework/hw03-johndoe
```

Create the branch:

```bash
git checkout -b homework/hwNN-your-nickname
```

## 3. Add your solution

Place your implementation in the following directory:

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
        ├── Program.cs
        └── ...
```

## 4. Commit your changes

```bash
git add .
git commit -m "Add homework HWNN by <Nickname>"
```

## 5. Push your branch

```bash
git push -u origin homework/hwNN-your-nickname
```

## 6. Keep your branch up to date (if `main` changes)

If new commits are added to the `main` branch before your Pull Request is merged, update your branch before continuing your work or requesting a review.

### Step 1. Save your work

```bash
git add .
git commit -m "WIP: save current progress"
```

### Step 2. Update `main`

```bash
git checkout main
git pull origin main
```

### Step 3. Merge the latest `main` into your branch

```bash
git checkout homework/hwNN-your-nickname
git merge main
```

If Git reports merge conflicts:

- Resolve the conflicts.
- Save the affected files.
- Complete the merge:

```bash
git add .
git commit
```

### Step 4. Push the updated branch

```bash
git push
```

> **Note:** Do **not** create a new branch. Continue working in the same homework branch.

## 7. Create a Pull Request

Open a Pull Request from your homework branch to the **`main`** branch.

Before submitting, verify that:

- ✅ Your branch was created from the latest `main`.
- ✅ Your homework is located in the correct directory.
- ✅ The project builds successfully (if applicable).
- ✅ Your Pull Request targets the `main` branch.
- ✅ The Pull Request title clearly identifies the homework.

---

# ✅ Submission Checklist

- [ ] Updated the local `main` branch
- [ ] Created a homework branch from `main`
- [ ] Added the solution to `hw/hwNN/<Nickname>/`
- [ ] Committed the changes
- [ ] Pushed the branch to GitHub
- [ ] Updated the branch if `main` changed
- [ ] Created a Pull Request targeting `main`
