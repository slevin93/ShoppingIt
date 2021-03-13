# ShoppingIt

## Description

## Clone

## Build

## Run

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
