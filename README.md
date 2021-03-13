# ShoppingIt

## Description

## Clone

Note: The following examples shows windows 10 terminal.

Create a folder where you want to clone the source code to. 

Open windows 10 terminal in that location.

### Initialise Git
Skip this step if you already have a folder where git is initialised.

```
git init
```

Clone source code.
```
git clone https://github.com/slevin93/ShoppingIt.git
```

## Build

Navigate to '/ShoppingIt/src/' and run the following donet cli command to build the project.

```
dotnet build
```

## Run
Navigate to '/ShoppingIt/src/' and run the following donet cli command to build the project.

```
dotnet run
```

## Contributing

### Branching Policy

ShoppingIt follows the gitflow branching policy

#### Feature
Each feature should be branched from develop using the following '/feaure/{feature-name}'. And example of a feature name would be '/feature/create-new-product'. When a feature is complete, it should be merged back into develop. A feature should never interact with master.

Creating a feature branch
```
git checkout develop
git checkout -b feature_branch
```

Merging a feature branch into develop
```
git checkout develop
git merge feature_branch
```

#### Release
ToDo: 

#### Hotfix
Hotfix branches are used to patch issues in production. Hotfixs are merged from master instead of develop. Note: This is the only branch that should be fork directly from master.

Once the fix is compete, the branch should be merged into both master and develop. 

Note:
A hotfix should only be made when a issue exists which breaks core functionality with no work around.

Creating a hotfix branch
```
git checkout master
git checkout -b hotfix_branch
```

Merging changes to master and develop
```
git checkout master
git merge hotfix_branch
git checkout develop
git merge hotfix_branch
git branch -D hotfix_branch
```

### Coding Style

### Third Party
