import { Component, Inject, HostListener } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.css']
})
export class ModalComponent {

    name;

    constructor(private dialogRef: MatDialogRef<ModalComponent>,
        @Inject(MAT_DIALOG_DATA) private data: any
    ) {
        this.name = data.name;
    }


    status = [{
        id: 1, name: 'Siparis Alindi'
    },
    {
        id: 2, name: 'Yola Cikti'
    },
    {
        id: 3, name: 'Dagitim Merkezinde'
    },
    {
        id: 4, name: 'Dagitima Cikti'
    },
    {
        id: 5, name: 'Teslim Edildi'
    },
    {
        id: 6, name: 'Teslim Edilemedi'
    },
    ];

    @HostListener('document:keyup.escape') onClose() {
        this.onCancel();
    }

    onCancel() {
        this.dialogRef.close();
    }

    onSubmit() {
        this.dialogRef.close();
    }




}
