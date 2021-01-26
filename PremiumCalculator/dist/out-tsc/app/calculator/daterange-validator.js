export class DateRangeValidators {
    static range(min, max) {
        return (c) => {
            let minDate = new Date(min);
            let maxDate = new Date(max);
            if (c.value && (c.value < minDate || c.value > maxDate)) {
                return { range: true };
            }
            return null;
        };
    }
}
//# sourceMappingURL=daterange-validator.js.map