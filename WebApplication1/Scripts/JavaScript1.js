var router = new VueRouter({
    mode: 'history',
    routes: []
});


const app = new Vue({
    router,
    el: '#CreateUser',
    data: {
        errors: [],
        name: null,
        email: null,
        familia: null,
        telephone: null,
        id:null
    },
    mounted: function () {
        this.$nextTick(function () {
            this.name = this.$route.query.name;
            console.log(this.name);
            this.email = this.$route.query.email;
            console.log(this.email);
            this.familia = this.$route.query.familia;
            console.log(this.familia);
            this.telephone = this.$route.query.telephone;
            console.log(this.telephone);
            this.id = this.$route.query.id;
            console.log(this.id);
        })
    },
    methods: {
        checkForm: function (e) {
            this.errors = [];

            if (!this.name) {
                this.errors.push('Укажите имя.');
            }
            if (!this.email) {
                this.errors.push('Укажите электронную почту.');
            } else if (!this.validEmail(this.email)) {
                this.errors.push('Укажите корректный адрес электронной почты.');
            }
            if (!this.familia) {
                this.errors.push('Укажите фамилию.');
            }
            if (!this.telephone) {
                this.errors.push('Укажите номер телефона.');
            } else if (!this.validTelephone(this.telephone)) {
                this.errors.push('Укажите номер телефона в соотетствии с форматом.');
            }

            if (!this.errors.length) {
                return true;
            }

            e.preventDefault();
        },
        validEmail: function (email) {
            var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        },
        validTelephone: function (telephone) {
            var re = /^\8{1,3}\s?\(9\d{2}\)\s?\d{3}(\d{2}){2}$/;
            return re.test(telephone);
        }
    }
})
