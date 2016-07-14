export class Directory {
    name: string;
    directories: Array;
    files: Array;
    expanded: boolean;
    checked: boolean;

    constructor(name, directories, files) {
        this.name = name;
        this.directories = directories;
        this.files = files;
        this.expanded = false;
        this.checked = false;
    }

    toogle() {
        this.expanded = !this.expanded;
    }

    check() {
        let newState = !this.checked;
        this.checked = newState;
        this.checkRecursive(newState);
    }

    checkRecursive(state) {
        this.directories.forEach(d => {
            d.checked = state;
            d.checkRecursive(state);
        })
    }
}