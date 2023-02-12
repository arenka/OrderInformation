import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalComponent } from './modal/modal.component';
import { Store } from './services/store.service';
import swal from "sweetalert2";


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
})

export default class AppComponent implements OnInit {
    title = 'order list';

    constructor(public store: Store, public dialog: MatDialog) {
    }
    ngOnInit(): void {
        this.store.loadOrders()
            .subscribe(() => { });
    }

    orderIds: Array<any> = [];
    name:any;
    onChange(ids: number, event: any, orderNo: any) {
        if (event.target.checked) {
            this.orderIds.push(ids);
            this.name = orderNo;
        } else {
            let index = this.orderIds.indexOf(ids);
            this.orderIds.splice(index, 1);
        }
    }
    openModal() {
        console.log(this.orderIds);
        if (this.orderIds.length >  0) {
            const dialogRef = this.dialog.open(ModalComponent, { data: { name: this.name }, disableClose: true });
            dialogRef.afterClosed().subscribe((submit) => {

            })
        } else {
            swal.fire({
                title: 'Hata!',
                text: 'Siparis seciniz...'
            });
        }
    }

}