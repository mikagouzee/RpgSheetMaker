import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from '../models/Models';


@Component
export default class CharacterCreationComponent extends Vue {

    characterName: string = '';

    selectedJob: string = '';

    jobs: string[] = [];

    onClick() {
        console.log('Current character : ' + this.characterName);
        console.log('Current game : ' + this.$store.state.game.name);

        var charac: any =
            {
                name: this.characterName,
                careername: this.selectedJob,
                gamename: this.$store.state.game.name
            }

        console.log(JSON.stringify(charac))

        fetch(`http://localhost:53713/api/Character/${this.$store.state.game.name}/creation`,
            {
                method: 'post',
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(charac)
            })
            .then(data => console.log(data))
            .then(() => { this.$router.push({ name: 'details', params: { characterName: this.characterName } }) });
    }

    mounted() {
        this.jobs = this.$store.state.game.jobs;
        this.selectedJob = this.jobs[0];
    }

}