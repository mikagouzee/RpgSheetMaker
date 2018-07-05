import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component
export default class CharacterDetailComponent extends Vue {
    @Prop({ type: String }) characterName: string;

    selectedCharacter: Character = {
        name: 'None chosen yet',
        baseAttributes: [],
        skills: [],
        stats: [],
        spendablePoints: [],
        profession: {
            Name: '',
            JobSkills:[] 
        }
    }

    mounted() {
        console.log(this.characterName);

        fetch('http://localhost:53713/api/FalloutCharacter/' + this.characterName)
            .then(response => response.json() as Promise<Character>)
            .then(data => {
                this.selectedCharacter = data;
            });

        console.log(this.selectedCharacter);
    }
}


interface Character {
    name: string,
    profession: Career,
    baseAttributes: Caracteristic[],
    skills: Caracteristic[],
    stats: Caracteristic[],
    spendablePoints: Caracteristic[]
}

interface Caracteristic {
    Name: string,
    Score: number
}


interface Career {
    Name: string,
    JobSkills: Caracteristic[]
}