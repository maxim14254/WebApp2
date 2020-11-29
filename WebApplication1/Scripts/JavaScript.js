const app = new Vue({
    el: '#CreateUser',
    data: {
        errors: [],
        name: null,
        email: null,
        familia: null,
        telephone: null
    },
    methods: {
        checkForm:function(e) {
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
