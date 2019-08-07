export class DataManipulation {
    public BuildName(firstName: string, middleName: string, lastName: string, suffix: string,
                     businessName: string, ownerName: string, joint: string, showNewFieldsFeature: boolean): string {

        let firstHalfName = '';
        let lastHalfName = '';

        if (suffix) {
            const lastCharSuffix: string = suffix[suffix.length - 1];
            if (lastCharSuffix !== '.') {
                suffix = suffix + '.';
            }

            if (lastName) {
                firstHalfName = lastName + ' ' + suffix;
            } else {
                firstHalfName = suffix;
            }
        } else {
            if (lastName) {
                firstHalfName = lastName;
            }
        }

        if (middleName) {
            const middleInital: string = middleName[0];
            if (firstName) {
                lastHalfName = firstName + ' ' + middleInital;
            } else {
                lastHalfName = middleInital;
            }
        } else {
            if (firstName) {
                lastHalfName = firstName;
            }
        }

        let name = null;

        if (businessName) {
            name = businessName;
        } else if (lastHalfName && firstHalfName) {
            name = firstHalfName + ', ' + lastHalfName;
        } else if (lastHalfName) {
            name = lastHalfName;
        } else if (firstHalfName) {
            name = firstHalfName;
        } else {
            // if you've gotten this far then the typical name has not been provided and return the
            // owner name which is only provided in pending data
            name = ownerName;
        }

        let jointIndicator = null;
        if (joint && joint.toUpperCase() === 'Y' && showNewFieldsFeature) {
            jointIndicator = '*';
        }

        if (jointIndicator) {
            name = name + jointIndicator;
        }
        return name;
    }
}
