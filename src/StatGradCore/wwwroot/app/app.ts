
import {Component, OnInit} from 'angular2/core';
import {bootstrap} from 'angular2/platform/browser';
import {TreeView} from './treeview.ts';
import {Directory} from './directory.ts';

@Component({
    selector: 'my-app',
    template: '<treeview [directories]="directories"></treeview>',
    directives:[TreeView]
})
export class AppComponent {
    directories: Array;
    
    constructor() {
        let PremierLeague = new Directory('Premier League', [], ['Arsenal', 'Chelsea', 'Liverpool', 'Man Unt']);
        let Primera = new Directory('Primera', [], ['Bercelona', 'Real Madrid', 'Atletico M']);
        let Leagues = new Directory('Leagues', [PremierLeague, Primera], []);
        let Teams = new Directory('Teams', [], ['Bayern', 'Milan']);
        this.directories = [Leagues, Teams];
    }
}

bootstrap(AppComponent);