import { Component} from '@angular/core';

//pass object configuration, to be used as a component
@Component({
    selector: 'app-server',
    templateUrl: './server.component.html'
})
export class ServerComponent {
    serverId: string = "10";
    serverStatus: string = 'offline';
    serverOff: boolean = true;
    updateInTwoWayBinding: string = "init";

    constructor(){
        setTimeout(() => {
            this.serverOff = false;
        }, 2000);
    }

    getServerStatus(){
        return this.serverStatus;
    }

    updateMyServerDescription(event:Event){
        this.serverId = (<HTMLInputElement>event.target).value;
    }

    addServer(){
        this.serverStatus = ". My new server is" + this.serverId;
    }
}