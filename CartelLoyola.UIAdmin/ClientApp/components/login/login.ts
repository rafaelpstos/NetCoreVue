import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import * as a from '../../global'

@Component
export default class LoginComponent extends Vue {

    user: string = '';
    pass: string = '';

    Login(): void {

        let dados = {
            Username: this.user,
            Password: this.pass
        }

        fetch('api/Login/LoginUsuario', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(dados)
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                console.log(data)
                a.setToken(data.token, data.username);
                localStorage.setItem('TOKEN', data.token);
                this.$router.push({ path: '/dashboard' })
            }
        });

    }
}