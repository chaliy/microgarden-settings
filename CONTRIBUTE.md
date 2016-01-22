## Environment

### Requirements

   - PostgreSQL 9+
   - node 5+
   - npm 3+   
   - dnx 1+


### Atom

   - omnisharp-atom
   - editorconfig
   - linter-eslint
   - language-babel
   - language-powershell

### Misc

    - install-package postgresql
    - dnu commands install Microsoft.Dnx.Watcher
    - Postman collection - https://www.getpostman.com/collections/b06299416dcc0d19a055

### Ren dev server

    start powershell 'cd \src\MicroGarden.Settings\;npm run dev'
    dnx-watch --project .\src\MicroGarden.Settings\project.json dev    
    start http://localhost:53469


## Maintanance

   cd \src\MicroGarden.Settings
   npm outdated
   npm update --save
   npm update --save-dev
