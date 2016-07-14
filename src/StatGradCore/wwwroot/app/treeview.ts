import {Component, Input} from 'angular2/core';
import {Directory} from './directory';

@Component({
    selector: 'treeview',
    templateUrl: './html/treeview.html',
    directives: [TreeView]
})

export class TreeView {
    @Input directories: Array<Directory>;
}