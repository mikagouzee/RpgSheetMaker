import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from './Models';

@Component
export default class CharacterDetailComponent extends Vue {
    @Prop({ type: String }) characterName: string;

    selectedCharacter: Character = {
        name: 'None chosen yet',
        gameName: 'none',
        baseAttributes: [],
        skills: [],
        stats: [],
        spendablePoints: [],
        profession: {
            name: '',
            jobSkills:[] 
        }
    }

    mounted() {
        console.log(this.characterName);

        fetch('http://localhost:53713/api/FalloutCharacter/' + this.characterName)
            .then(response => response.json() as Promise<Character>)
            .then(data => {
                this.selectedCharacter = data;
            });

        //console.log("Job : " + this.selectedCharacter.Profession.Name);
        //console.log("skills : " + this.selectedCharacter.Profession.JobSkills);
    }
}
